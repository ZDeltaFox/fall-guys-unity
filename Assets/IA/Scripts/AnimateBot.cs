using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateBot : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 latePos;
    public GameObject obj;
    private Animator anim;

    void Start() 
    {
        anim = GetComponent<Animator>();
        StartCoroutine(UpdateIE());
    }

    void FixedUpdate()
    {
        pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);

        if (Mathf.Round(pos.x) != Mathf.Round(latePos.x)) 
        {
            if (Mathf.Round(pos.y) != Mathf.Round(latePos.y)) {anim.SetInteger("AnimState", 2);}

            else {anim.SetInteger("AnimState", 1);}
        }

        else {if (Mathf.Round(pos.y) != Mathf.Round(latePos.y)) {anim.SetInteger("AnimState", 2);}}
        
        if (Mathf.Round(pos.y) == Mathf.Round(latePos.y) && Mathf.Round(pos.x) == Mathf.Round(latePos.x)) {anim.SetInteger("AnimState", 0);}
    }

    IEnumerator UpdateIE()
    {
        latePos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(UpdateIE());
    }
}
