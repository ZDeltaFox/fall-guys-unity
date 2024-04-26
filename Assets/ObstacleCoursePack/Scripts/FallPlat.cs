using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlat : MonoBehaviour
{
	public float fallTime = 0.5f;


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
			Destroy(gameObject);
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
	}

	IEnumerator OnStart() 
	{
		yield return new WaitForSeconds(3f);
		Started = true;
	}

	bool Started = false;
}
