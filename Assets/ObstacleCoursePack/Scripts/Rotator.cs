using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  [Header ("Velocidad")]
  public float speed = 3f;
  public float Sumar = 3f;

  void Start()
  {
    StartCoroutine(MoreSpeed());
  }

  void Update()
  {
		transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
	}

  IEnumerator MoreSpeed()
  {
    yield return new WaitForSeconds(5f);
    speed += Sumar / 100;
    StartCoroutine(MoreSpeed());
  }
}
