using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator2 : MonoBehaviour
{
  [Header ("Velocidad")]
  public float speed;
  float sumar;
  public float Sumar;
  bool rotIn;
  float inSpeed;

  void Start()
  {
    inSpeed = speed;
    sumar = Sumar;
  }

  void Update()
  {
    speed += Sumar / 1000;

    if (speed >= inSpeed) {rotIn = false;}
    if (speed <= -inSpeed) {rotIn = true;}
    if (rotIn) {Sumar = sumar;}
    else {Sumar = -sumar;}
	  transform.Rotate(0f, 0f, speed * Time.deltaTime / 0.01f, Space.Self);
	}
}
