using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	public float addForce;
	public float stunTime = 0.5f;
	private Vector3 hitDir;

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
				hitDir = contact.normal;
				collision.gameObject.GetComponent<CharacterControls>().HitPlayer(-hitDir * force, stunTime);
				return;
			}

			if (collision.gameObject.tag == "Bot")
			{
				hitDir = contact.normal;
				collision.gameObject.GetComponent<IAMovement>().HitPlayer(-hitDir * force / 2, stunTime);
				return;
			}
		}
		/*if (collision.relativeVelocity.magnitude > 2)
		{
			if (collision.gameObject.tag == "Player")
			{
				//Debug.Log("Hit");
				collision.gameObject.GetComponent<CharacterControls>().HitPlayer(-hitDir*force, stunTime);
			}
			//audioSource.Play();
		}*/
	}

	void Start()
	{
		StartCoroutine(MoreForce());
	}

	IEnumerator MoreForce()
	{
		yield return new WaitForSeconds(5f);
		force += addForce;
		StartCoroutine(MoreForce());
	}
}
