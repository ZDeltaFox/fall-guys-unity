using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
	public float fallTime = 0.5f;
    private Rigidbody rb;

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
		if (Started)
		{
			yield return new WaitForSeconds(time);
			rb.isKinematic = false;
			rb.constraints = RigidbodyConstraints.None;
		}

		else
		{
			yield return new WaitForSeconds(0.01f);
			StartCoroutine(Fall(fallTime));
		}
	}

	void Start() 
	{
		StartCoroutine(OnStart());
		Started = false;
        rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	IEnumerator OnStart() 
	{
		yield return new WaitForSeconds(3f);
		Started = true;
	}

	bool Started = false;
}