using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 latePos;
    public GameObject obj;

    [Header ("Volume")]
    public AudioClip[] newEffect;
    private AudioSource audio;
    /*[Range (0, 1)]
    public float Volume;*/

    void Start() 
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(UpdateIE());

        //audio.volume = Volume;
    }

    void FixedUpdate()
    {
        pos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);

        if (Mathf.Round(pos.x) != Mathf.Round(latePos.x)) 
        {
            if (Mathf.Round(pos.y) != Mathf.Round(latePos.y)) {audio.clip = newEffect[2]; audio.Play();}

            audio.clip = newEffect[1];
        }

        else {if (Mathf.Round(pos.y) != Mathf.Round(latePos.y)) {audio.clip = newEffect[2]; audio.Play();}}
        
        if (Mathf.Round(pos.y) == Mathf.Round(latePos.y) && Mathf.Round(pos.x) == Mathf.Round(latePos.x)) {audio.clip = newEffect[0]; audio.Play();}
    }

    IEnumerator UpdateIE()
    {
        latePos = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z);
        yield return new WaitForSeconds(1f);
        StartCoroutine(UpdateIE());
    }
}
