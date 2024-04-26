using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class IAMovement : MonoBehaviour
{
    [Header ("IA")]
    [Range (20, 2)]
    public int BotID;

    public float speed;
    float stoppingDistance = 3.0f;
    float maxRandomAngle = 45.0f;

	public float jumpForce = 10f;

    //public float stopRadius = 5.0f;

    private List<Transform> pointsToVisit = new List<Transform>();
    private int currentPointIndex = 0;

	public bool isSelectableHere;
	public bool SelectPath1OrPath2;
    public int isPathA;

	public bool stopMovement = false;

    [Header ("Parameters")]
	public float gravity = 40f;
	float multiplicar = 1;
	private PhotonView photonView;
	public float raycastDistance = 50f;
	/*public float speed = 10.0f;
	public float airVelocity = 8f;*/
	
	/*public float maxVelocityChange = 10.0f;*/
	public float jumpHeight = 2.0f;
	/*public float maxFallSpeed = 20.0f;
	public float rotateSpeed = 25f; //Speed the player rotate
	private Vector3 moveDir;*/
	[Header ("OnCollide")]
	public string obstacleTag = "Obstacle";
	public float timeToWakeUp = 0.5f;
	float TimeToWakeUp;
	//public float timer;
	//[Header ("Objects")]
	private Rigidbody rb;
	
	//[Header ("ID")][Range (1, 20)] public int ID;

	private float distToGround;

	private bool canMove = true; //If player is not hitted
	private bool isStuned = false;
	private bool wasStuned = false; //If player was stunned before get stunned another time
	private float pushForce;
	private Vector3 pushDir;

	private bool slide = false;

	/*[Header ("Detectors")]
	public GameObject wallDetector;
	public GameObject obstacleDetector;*/

	[Header ("Respawn")]
	public Vector3 endPosition;
	public Vector3 checkPoint;
	public string[] scenesInWhiteList;
	public bool canRespawn;
    //public float restartPointIndex;

	[Header ("Qualify")]
	public bool isQualified;
	//public static bool _IsQualified;

	[Header ("Debug")]
	public Color noHitRayColor = Color.white;
	public Color hitRayColor = Color.red;

	[Header ("Bug Solutions")]
	public int substractor;
	public int divisor;

	float mode = 3;

	NavMeshAgent agent;

    void Start() 
    {
		if (PhotonNetwork.InRoom)
		{
			Destroy(gameObject);
		}
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), true);
        //Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Finish"), LayerMask.NameToLayer("Ignore Raycast"), true);
        Physics.IgnoreLayerCollision(layer1: 2, layer2: 9, ignore: true);
		
		agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        GetComponent<Rigidbody>().isKinematic = true;

        stoppingDistance = Random.Range(1.0f, 2.0f);
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
        if (PlayerID._players >= BotID) {Destroy(gameObject);}

        gameObject.transform.position = Spawners.positions[BotID - 1];
        isPathA = Random.Range(0, 2);
        speed = Random.Range(6.0f, 12.0f);

        // Obtener los objetos con el tag "IAPoints" del camino seleccionado y almacenarlos en la lista.
        GameObject[] pointObjects;
        if (isPathA == 0) {pointObjects = GameObject.FindGameObjectsWithTag("IAPointsA");} 
        else {pointObjects = GameObject.FindGameObjectsWithTag("IAPointsB");}
        foreach (GameObject pointObject in pointObjects) 
        {
            pointsToVisit.Add(pointObject.transform);
        }
        rb.freezeRotation = true;
		rb.useGravity = false;

		checkPoint = transform.position;

        //restartPointIndex = 0;

		if (isSelectableHere)
		{
			if (SelectPath1OrPath2)
			{
				isPathA = 0;
			}

			else
			{
				isPathA = 1;
			}
		}
    }

	bool IsGrounded() {return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);}

	void FixedUpdate()
	{
		//DetectObstacle();
		transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
	}

	#region DetectObstacle
	/*private void DetectObstacle()
    {
		if (IsGrounded())
		{
			// Rayos en todas las direcciones, incluyendo diagonales hacia abajo
			Vector3[] directions = new Vector3[] {
				transform.forward, 
				-transform.forward, 
				transform.right, 
				-transform.right, 
				transform.forward + transform.right, 
				transform.forward - transform.right,
				-transform.forward + transform.right,
				-transform.forward - transform.right,
				Vector3.down,
				Vector3.down + transform.forward,
				Vector3.down - transform.forward,
				Vector3.down + transform.right,
				Vector3.down - transform.right,
				Vector3.down + transform.forward + transform.right,
				Vector3.down + transform.forward - transform.right,
				Vector3.down - transform.forward + transform.right,
				Vector3.down - transform.forward - transform.right
			};

			Vector3 velocity = rb.velocity;

			foreach (Vector3 direction in directions)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, direction, out hit, raycastDistance))
				{
					if (hit.collider.CompareTag(obstacleTag))
					{
						rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
						//break;
						Debug.DrawRay(transform.position, direction * raycastDistance, hitRayColor, 0.1f);
					}

					else 
					{
						Debug.DrawRay(transform.position, direction * raycastDistance, noHitRayColor, 0.1f);
					}
				}
			}
		}
	}*/
	#endregion

	float CalculateJumpVerticalSpeed() 
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt((2 * jumpHeight * gravity) * multiplicar * mode);
	}

	private IEnumerator Decrease(float value, float duration)
	{
		/*if (photonView.IsMine)
        {*/
			if (isStuned) {wasStuned = true;}
			isStuned = true;
			canMove = false;

			float delta = 0;
			delta = value / duration;

			for (float t = 0; t < duration; t += Time.deltaTime)
			{
				yield return null;
				if (!slide) //Reduce the force if the ground isnt slide
				{
					pushForce = pushForce - Time.deltaTime * delta;
					pushForce = pushForce < 0 ? 0 : pushForce;
					//Debug.Log(pushForce);
				}
				rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); //Add gravity
			}

			if (wasStuned) {wasStuned = false;}
			else
			{
				isStuned = false;
				canMove = true;
			}
		//}
	}

    public void HitPlayer(Vector3 velocityF, float time)
	{
		/*if (!isQualified)
        {*/
			rb.velocity = velocityF;

			pushForce = velocityF.magnitude;
			pushDir = Vector3.Normalize(velocityF);
			StartCoroutine(Decrease(velocityF.magnitude, time));
		//}
	}

    public void LoadCheckPoint() 
	{
		/*if (photonView.IsMine) 
		{*/
			if (canRespawn)
			{
				transform.position = checkPoint;
                currentPointIndex = 0;
			}

			else
			{
				if (PhotonNetwork.InRoom) {photonView.RPC("Eliminar", RpcTarget.All);}
				else {Eliminar();}
			}
		//}
	}

	private void OnCollisionEnter(Collision other) 
	{
		/*if (photonView.IsMine)
        {*/
			if (other.gameObject.tag == obstacleTag)
			{
				TimeToWakeUp = timeToWakeUp;
				//timer = 0;
			}

			/*if (other.gameObject.CompareTag(obstacleTag))
			{
				Vector3 normal = other.contacts[0].normal;
				rb.velocity = Vector3.Reflect(rb.velocity, normal);
			}

			if (other.gameObject.tag == "Terrain")
			{
				PlayerAnimation.IsGrounded = true;
			}
		}*/
	}

    private void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "GravityM") {gravity = 10f; multiplicar = 3;}

		if (other.gameObject.tag == "GravityP") {gravity = 120f; /*multiplicar = 2 / 10;*/}

		//if (other.gameObject.tag == "Classify") {if (!isQualified) {isQualified = true; photonView.RPC("Classicar", RpcTarget.All); rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);}}

		if (other.gameObject.tag == obstacleTag) {Vector3 velocity = rb.velocity; rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);}

		if (other.gameObject.tag == "Wall") {stopMovement = true;}
	}


	private void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "GravityM" || other.gameObject.tag == "GravityP") {gravity = 40f; multiplicar = 1;}

		if (other.gameObject.tag == "Wall") {stopMovement = false;}
	}

	void Update() 
	{
		rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

		/*if (canMove)
		{*/
			if (currentPointIndex >= pointsToVisit.Count) 
			{
				Physics.IgnoreLayerCollision(layer1: 2, layer2: 7, ignore: false);
				/*Si ya visitó todos los puntos, detiene el movimiento.*/ 
				return;
				for (float i = 0; i < 0.5; i++)
				{
					endPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
					if (!isQualified) 
					{
						isQualified = true; 
						if (PhotonNetwork.InRoom) {photonView.RPC("Classicar", RpcTarget.All);}
						else {Classicar();}
						rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
					}
				}

				gameObject.transform.position = endPosition;
			}

			Transform currentPoint = pointsToVisit[currentPointIndex];
			Vector3 direction = (currentPoint.position - transform.position).normalized;

			// Agregar un ángulo aleatorio a la dirección actual.
			float randomAngle = Random.Range(-maxRandomAngle, maxRandomAngle);
			Quaternion randomRotation = Quaternion.AngleAxis(randomAngle, Vector3.up);
			direction = randomRotation * direction;

			float distance = Vector3.Distance(transform.position, currentPoint.position);

			/*if (currentPointIndex < pointsToVisit.Count) 
			{
				transform.LookAt(pointsToVisit[currentPointIndex]);
			}*/

			Vector3 targetPosition = pointsToVisit[currentPointIndex].position;
			if (agent.remainingDistance <= stoppingDistance) 
			{
				// Si el objeto ya llegó al punto actual, pasa al siguiente punto.
				currentPointIndex++;
			}

			/*else 
			{
				// Mueve el objeto hacia el punto actual.
				transform.position += direction * speed * Time.deltaTime;
			}*/
			agent.SetDestination(targetPosition);

			if (agent.remainingDistance >= stoppingDistance * 3)
			{
				transform.LookAt(currentPoint);
			}

			for (int i = 0; i < scenesInWhiteList.Length; i++)
			{
				if (SceneManager.GetActiveScene().name == scenesInWhiteList[i])
				{
					canRespawn = true;
					mode = 1;
				}
			}
		//}
    }

    [PunRPC]
	void Classicar()
	{
		Qualified._Qualifieds += Mathf.Round((1 / divisor) - substractor);
	}

	[PunRPC]
	void Eliminar()
	{
		Qualified._DeathPlayers++;
	}
}
