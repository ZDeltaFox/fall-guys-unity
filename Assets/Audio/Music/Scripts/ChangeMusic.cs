using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public float timer;
    public int musicNumber = 1;
    public AudioClip[] newMusic; // Nueva música que se va a asignar al objeto

    private AudioSource audioSource; // Componente AudioSource del objeto

    
    int mN;

    public int[] times;

    void Start()
    {
        // Obtener el componente AudioSource del objeto
        audioSource = GetComponent<AudioSource>();
        musicNumber = 1;
    }

    void Update()
    {
        if (mN == 11)
        {
            musicNumber = 1;
            mN = 1;
        }

        if (mN >= 11)
        {
            musicNumber = 1;
            mN = 1;
        }

        timer += Time.deltaTime;
        // Si se presiona la tecla "M", cambiar la música del objeto
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKey("left ctrl"))
        {
            if (musicNumber < 10)
            {
                musicNumber++;
            }

            else
            {
                musicNumber = 1;
            }

            // Reproducir la nueva música
            audioSource.Play();
            timer = 0;
        }

        if (timer >= times[musicNumber - 1])
        {
            if (musicNumber < 10)
            {
                musicNumber++;
            }

            else
            {
                musicNumber = 1;
            }

            timer = 0;
        }

        // Asignar la nueva música al objeto
        if (mN != musicNumber)
        {
            audioSource.clip = newMusic[musicNumber - 1];
            mN = musicNumber;
            audioSource.Play();
        }
    }
    #region Priority
    /*public AudioSource audioSource1;
    public AudioSource audioSource2;

    void Start()
    {
        // Asigna una prioridad más alta al audioSource1
        audioSource1.priority = 1;

        // Asigna una prioridad más baja al audioSource2
        audioSource2.priority = 0;
    }*/
    #endregion
}
