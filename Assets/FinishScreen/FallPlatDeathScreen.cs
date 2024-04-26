using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class FallPlatDeathScreen : MonoBehaviourPunCallbacks
{
	public float fallTime = 7.5f;

	public float velocidad;
    public float anguloMaximo;
    public float anguloMinimo;
	public float anguloAleatorio;
	public float gravity = 40f;
	float gn = -9.81f;

	private Rigidbody rb;

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.constraints = RigidbodyConstraints.FreezeAll;
		StartCoroutine(OnStart());
		Started = false;
	}

	void FixedUpdate()
	{
		transform.rotation = Quaternion.Euler(0f, 0f, anguloAleatorio * Time.deltaTime);
		rb.AddForce(new Vector3(0, -gn * GetComponent<Rigidbody>().mass, 0));
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				StartCoroutine(Fall(fallTime));
			}
		}
	}

	IEnumerator Fall(float time)
	{
		if (Qualified.IsChangingRoom)
		{
			if (!CharacterControls._IsQualified)
			{
				if (Started)
				{
					yield return new WaitForSeconds(time);
					anguloAleatorio = Random.Range(anguloMinimo, anguloMaximo);
					rb.isKinematic = false;
					rb.constraints = RigidbodyConstraints.None;
					gn = gravity;

					yield return new WaitForSeconds(5f);
					PhotonNetwork.LeaveRoom();
					SceneManager.LoadScene("MainMenu");
				}

				else
				{
					yield return new WaitForSeconds(0.01f);
					StartCoroutine(Fall(fallTime));
				}
			}

			else
			{
				yield return new WaitForSeconds(6f);
				Rounds._thisRound++;
				PhotonNetwork.LoadLevel("RoomSelector");
			}
		}

		else
		{
			yield return new WaitForSeconds(0.3f);
			StartCoroutine(Fall(fallTime));
		}
	}

	IEnumerator OnStart() 
	{
		yield return new WaitForSeconds(3f);
		Started = true;
	}

	bool Started = false;
}
