using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    public static bool IsGrounded;
    private PhotonView photonView;

    void Start()
    {
        anim = GetComponent<Animator>();
        IsGrounded = true;
        if (PhotonNetwork.InRoom)
        {
            photonView = GetComponent<PhotonView>();
        }
    }

    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            if (photonView.IsMine)
            {
                if (!IsGrounded)
                {
                    //anim.SetTrigger("Jump");
                    anim.SetInteger("AnimState", 2);
                }

                if (IsGrounded)
                {
                    if (!InGameSettings.inSettings && !CharacterControls._IsQualified)
                    {
                        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right"))
                        {
                            /*anim.SetBool("Walk", true);
                            anim.SetBool("Idle", false);
                            anim.SetBool("Jump", false);*/
                            anim.SetInteger("AnimState", 1);
                        }
                    }

                    else
                    {
                        anim.SetInteger("AnimState", 0);
                    }

                    if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("up") && !Input.GetKey("left") && !Input.GetKey("down") && !Input.GetKey("right"))
                    {
                        /*anim.SetBool("Walk", false);
                        anim.SetBool("Idle", true);
                        anim.SetBool("Jump", false);*/
                        anim.SetInteger("AnimState", 0);
                    }
                }
            }
        }

        else
        {
            if (!IsGrounded)
            {
                //anim.SetTrigger("Jump");
                anim.SetInteger("AnimState", 2);
            }

            if (IsGrounded)
            {
                if (!InGameSettings.inSettings && !CharacterControls._IsQualified)
                {
                    if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right"))
                    {
                        /*anim.SetBool("Walk", true);
                        anim.SetBool("Idle", false);
                        anim.SetBool("Jump", false);*/
                        anim.SetInteger("AnimState", 1);
                    }
                }

                else
                {
                    anim.SetInteger("AnimState", 0);
                }

                if (!Input.GetKey("w") && !Input.GetKey("a") && !Input.GetKey("s") && !Input.GetKey("d") && !Input.GetKey("up") && !Input.GetKey("left") && !Input.GetKey("down") && !Input.GetKey("right"))
                {
                    /*anim.SetBool("Walk", false);
                    anim.SetBool("Idle", true);
                    anim.SetBool("Jump", false);*/
                    anim.SetInteger("AnimState", 0);
                }
            }
        }
    }
}
