using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;

public class MoveCam : MonoBehaviour
{
    #region Script
    /*//public float rotationSpeed = 50.0f;

    public float baseSpeed = 5.0f; // Velocidad base del objeto
    public float speedRange = 2.0f; // Rango máximo de velocidad
    public float audioScale = 50.0f; // Escala para ajustar la amplitud del análisis de audio
    public float currentSpeed; // Velocidad actual del objeto

    public AudioSource audioSource; // AudioSource que contiene la música que se está reproduciendo

    void Update()
    {
        //transform.RotateAround(transform.position, Vector3.right, Time.deltaTime * rotationSpeed);

        // Obtener los ángulos de Euler actuales de la rotación de la cámara
        //Vector3 currentRotation = transform.rotation.eulerAngles;

        // Sumar los ángulos de rotación en torno a los ejes Y y Z
        //currentRotation.y += Time.deltaTime * rotationSpeed;
        //currentRotation.z += Time.deltaTime * rotationSpeed;

        // Asignar la nueva rotación a la cámara
        //transform.rotation = Quaternion.Euler(currentRotation);



        // Obtener el valor de análisis de audio actual
        float audioValue = YourAudioAnalysisFunction();

        // Calcular la velocidad actual en función del valor de análisis de audio
        currentSpeed = baseSpeed + (audioValue * speedRange * audioScale);

        // Mover el objeto en la dirección hacia adelante
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    public float GetAudioValue(AudioSource audioSource)
    {
        // Obtener el valor actual de volumen del AudioSource
        float currentVolume = audioSource.volume;

        // Normalizar el valor de volumen entre 0 y 1
        float normalizedVolume = currentVolume / audioSource.clip.maxValue;

        return normalizedVolume;
    }*/
    #endregion
    
    public AudioSource audioSource;
    public float rotationSpeed = 50.0f;
    public float audioScale = 50.0f;
    public float rotationRange = 20.0f;

    void Update()
    {
        // Obtener el espectro de frecuencia de la música
        float[] spectrum = new float[256];
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // Calcular el valor promedio del espectro de frecuencia
        float average = 0.0f;
        for (int i = 0; i < spectrum.Length; i++)
        {
            average += spectrum[i];
        }
        average /= spectrum.Length;

        // Calcular la velocidad de rotación en función del valor promedio
        float rotationSpeed = Mathf.Lerp(0.0f, rotationRange, average * audioScale);

        // Rotar la cámara en el eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
