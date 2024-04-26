using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class RandomImpostor : MonoBehaviour
{
    [Header ("Impostor Select")]
    public float IF1;
    public float IF2;
    public static float ISF1;
    public static float ISF2;
    public GameObject I1;
    public GameObject I2;

    [Header ("Impostor Ini")]
    [SerializeField] public GameObject _impostorWindow;
    [SerializeField] public Text _impostorText;

    [Header ("Timers")]
    public float timer;
    public float timeDel = 4;

    [Header ("PV")]
    public PhotonView pv;



    void Start()
    {
        pv.GetComponent<PhotonView>();
    }

    void Update()
    {
        if (pv.IsMine)
        {
            if (LobbyNetworkManager.MyPlayerNumberCounter == 1)
            {
                if (timer <= timeDel)
                {
                    if (LobbyNetworkManager.SPlayerCounter == 10)
                    {
                        IF1 = Random.Range(1, LobbyNetworkManager.SPlayerCounter);
                        IF2 = Random.Range(1, LobbyNetworkManager.SPlayerCounter);
                    }

                    else
                    {
                        IF1 = Random.Range(1, LobbyNetworkManager.SPlayerCounter);
                        IF2 = 0;
                    }
                }

                if (ISF1 == ISF2)
                {
                    if (ISF1 >= 2) {IF1--;}
                    else {IF1++;}
                }

                I1.transform.position = new Vector3(ISF1, 1000, 0);
                I2.transform.position = new Vector3(ISF2, 1000, 0);
            }
        }

        else
        {
            if (timer >= timeDel)
            {
                //Destroy(gameObject);
            }
        }

        //if (LobbyNetworkManager.SPlayerCounter != 10) {_impostorText.text = "Hay 1 impostor entre nosotros";} 
        //else {_impostorText.text = "Hay 2 impostores entre nosotros";}
        _impostorText.text = "Hay 1 impostor entre nosotros";
        if (timer >= timeDel) {_impostorWindow.SetActive(false);}
        else {_impostorWindow.SetActive(true);}
        timer += Time.deltaTime;

        IF1 = (Mathf.Round(IF1));
        IF2 = (Mathf.Round(IF2));

        ISF1 = (Mathf.Round(IF1));
        ISF2 = (Mathf.Round(IF2));

        IF1 = 1;
        IF2 = 0;
    }
}
