using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
[RequireComponent (typeof (PhotonView))]
[RequireComponent (typeof (PhotonTransformView))]

public class CharacterControls : MonoBehaviour 
{
	[Header ("Parameters")]
	private PhotonView photonView;
	public float speed = 10.0f;
	public float airVelocity = 8f;
	public float gravity = 9.81f;
	public float maxVelocityChange = 10.0f;
	public float jumpHeight = 2.0f;
	public float maxFallSpeed = 20.0f;
	public float rotateSpeed = 25f; //Speed the player rotate
	private Vector3 moveDir;
	[Header ("OnCollide")]
	public string obstacleTag;
	public float timeToWakeUp;
	float TimeToWakeUp;
	public float timer;
	[Header ("Objects")]
	public GameObject cam;
	private Rigidbody rb;
	
	//[Header ("ID")][Range (1, 20)] public int ID;

	private float distToGround;

	private bool canMove = true; //If player is not hitted
	private bool isStuned = false;
	private bool wasStuned = false; //If player was stunned before get stunned another time
	private float pushForce;
	private Vector3 pushDir;

	private bool slide = false;

	[Header ("Respawn")]
	public Vector3 checkPoint;
	public string[] scenesInWhiteList;
	public bool canRespawn;

	[Header ("Qualify")]
	public bool isQualified;
	public static bool _IsQualified;

	void Awake () 
	{
		isQualified = false;
		_IsQualified = false;
		photonView = GetComponent<PhotonView>();
		Cursor.lockState = CursorLockMode.Locked;
    	Cursor.visible = false;
	}

	void  Start ()
	{
		//Physics.IgnoreLayerCollision(layer1: 2, layer2: 9, ignore: true);
		/*if (ID != PlayerID._ID)
		{
			cam.SetActive(false);
		}*/
		if (photonView.IsMine || !PhotonNetwork.InRoom)
		{
				gameObject.transform.position = Spawners.positions[PlayerID._ID - 1];
				// get the distance to ground
				distToGround = GetComponent<Collider>().bounds.extents.y;

				rb = GetComponent<Rigidbody>();
				
				rb.freezeRotation = true;
				rb.useGravity = false;

				checkPoint = transform.position;
				Cursor.visible = false;
		}
	}
	
	bool IsGrounded() {return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);}
	
	void FixedUpdate () 
	{
		if (photonView.IsMine || !PhotonNetwork.InRoom)
        {
			if (!InGameSettings.inSettings && !isQualified)
			{
				if (canMove)
				{
					if (moveDir.x != 0 || moveDir.z != 0)
					{
						if (timeToWakeUp <= timer)
						{
							Vector3 targetDir = moveDir; //Direction of the character

							targetDir.y = 0;
							if (targetDir == Vector3.zero) {targetDir = transform.forward;}
							Quaternion tr = Quaternion.LookRotation(targetDir); //Rotation of the character to where it moves
							Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * rotateSpeed); //Rotate the character little by little
							transform.rotation = targetRotation;
						}
					}
				}
			}

			if (IsGrounded())
			{
				if (timeToWakeUp <= timer)
				{
						
					// Calculate how fast we should be moving
					Vector3 targetVelocity = moveDir;
					targetVelocity *= speed;

					// Apply a force that attempts to reach our target velocity
					Vector3 velocity = rb.velocity;

					if (!InGameSettings.inSettings && !isQualified)
					{
						if (targetVelocity.magnitude < velocity.magnitude) //If I'm slowing down the character
						{
							targetVelocity = velocity;
							rb.velocity /= 1.1f;
						}
					}

					Vector3 velocityChange = (targetVelocity - velocity);
					velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
					velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
					velocityChange.y = 0;
	
					if (!InGameSettings.inSettings && !isQualified)
					{
						if (!slide) {if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f) {rb.AddForce(velocityChange, ForceMode.VelocityChange);}}
					
						else if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f)
						{
							rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
							//Debug.Log(rb.velocity.magnitude);
						}
					}
					if (!InGameSettings.inSettings && !isQualified)
					{
						// Jump
						if (canMove)
						{
							if (IsGrounded() && Input.GetButton("Jump")) {rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);}
						}
					}

					PlayerAnimation.IsGrounded = true;
				}
			}

			else
			{
				/*if (!InGameSettings.inSettings)
				{*/
					if (!slide)
					{
						Vector3 targetVelocity = new Vector3(moveDir.x * airVelocity, rb.velocity.y, moveDir.z * airVelocity);
						Vector3 velocity = rb.velocity;
						Vector3 velocityChange = (targetVelocity - velocity);
						velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
						velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
						rb.AddForce(velocityChange, ForceMode.VelocityChange);
						if (velocity.y < -maxFallSpeed) {rb.velocity = new Vector3(velocity.x, -maxFallSpeed, velocity.z);}

						PlayerAnimation.IsGrounded = false;
					}
					else if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f) 
					{
						rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
					}
				//}
			}
					
			//else {rb.velocity = pushDir * pushForce;}
			// We apply gravity manually for more tuning control
			rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));
			//rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0), ForceMode.Acceleration);
			rb.useGravity = false;

			if (Qualified.IsChangingRoom)
			{
				cam.SetActive(false);
			}
		}
	}

	private void Update()
	{
		if (photonView.IsMine || !PhotonNetwork.InRoom)
        {
			_IsQualified = isQualified;
			if (IsGrounded()) {timer += Time.deltaTime;}

			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			Vector3 v2 = v * cam.transform.forward; //Vertical axis to which I want to move with respect to the camera
			Vector3 h2 = h * cam.transform.right; //Horizontal axis to which I want to move with respect to the camera
			moveDir = (v2 + h2).normalized; //Global position to which I want to move in magnitude 1

			RaycastHit hit;
			if (Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f))
			{
				if (hit.transform.tag == "Slide") {slide = true;}
				else {slide = false;}
			}
		}

		else
		{
			cam.SetActive(false);
		}

		for (int i = 0; i < scenesInWhiteList.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == scenesInWhiteList[i])
           	{
                canRespawn = true;
            }
        }
	}

	float CalculateJumpVerticalSpeed () 
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt((2 * jumpHeight * gravity) * multiplicar);
	}

	public void HitPlayer(Vector3 velocityF, float time)
	{
		if (photonView.IsMine)
        {
			rb.velocity = velocityF;

			pushForce = velocityF.magnitude;
			pushDir = Vector3.Normalize(velocityF);
			StartCoroutine(Decrease(velocityF.magnitude, time));
		}
	}

	public void LoadCheckPoint() 
	{
		if (photonView.IsMine || !PhotonNetwork.InRoom) 
		{
			if (canRespawn)
			{
				transform.position = checkPoint;
			}

			else
			{
				if (PhotonNetwork.InRoom) {photonView.RPC("Eliminar", RpcTarget.All);}
				else {Eliminar();}
			}
		}
	}

	private IEnumerator Decrease(float value, float duration)
	{
		if (photonView.IsMine  || !PhotonNetwork.InRoom)
        {
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
		}
	}

	private void OnCollisionEnter(Collision other) 
	{
		if (photonView.IsMine  || !PhotonNetwork.InRoom)
        {
			if (other.gameObject.tag == obstacleTag)
			{
				TimeToWakeUp = timeToWakeUp;
				timer = 0;
			}

			/*if (other.gameObject.CompareTag(obstacleTag))
			{
				Vector3 normal = other.contacts[0].normal;
				rb.velocity = Vector3.Reflect(rb.velocity, normal);
			}

			if (other.gameObject.tag == "Terrain")
			{
				PlayerAnimation.IsGrounded = true;
			}*/
		}
	}

	/*private void OnCollisionExit(Collision other) 
	{
		if (other.gameObject.tag == "Terrain")
		{
			PlayerAnimation.IsGrounded = false;
		}
	}*/

	private void OnTriggerEnter(Collider other) 
	{
		if (photonView.IsMine  || !PhotonNetwork.InRoom)
        {
			if (other.gameObject.tag == "GravityM")
			{
				gravity = 10f;
				multiplicar = 3;
			}

			if (other.gameObject.tag == "GravityP")
			{
				gravity = 120f;
				//multiplicar = 2 / 10;
			}

			if (other.gameObject.tag == "Classify")
			{
				if (!isQualified)
				{
					isQualified = true;
					if (PhotonNetwork.InRoom) {photonView.RPC("Classicar", RpcTarget.All);}
					else {Classicar();}
					rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
				}
			}
		}
	}

	private void OnTriggerExit(Collider other) 
	{
		gravity = 40f;
		multiplicar = 1;
	}

	float multiplicar = 1;

	[PunRPC]
	void Classicar()
	{
		Qualified._Qualifieds++;
		Qualified._RealPlayersQualified++;
	}

	[PunRPC]
	void Eliminar()
	{
		Qualified._DeathPlayers++;
	}
}
