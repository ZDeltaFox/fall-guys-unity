using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public bool canRespawn;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (canRespawn)
            {
			    col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            }

            else
            {
                KillPlayer.playerIsKilled = true;
            }
		}

        if (col.gameObject.tag == "Bot")
        {
            col.gameObject.GetComponent<IAMovement>().LoadCheckPoint();
        }
	}
}
