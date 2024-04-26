using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DownloadGame : MonoBehaviourPunCallbacks
{
    float downloaded;
    bool canDownload;

    float timer;
    float downloadTime;
    float unconnectedTimer;
    float roundTime;
    float timeLeft;
    public float downloading;

    [HideInInspector]
    public TMP_Text tDownloading;
    public TMP_Text Tiempo;
    [HideInInspector]
    public Image downloadI;

    bool isDownloading;
    [HideInInspector]
    public Button downloadButtonGO;
    [HideInInspector]
    public AudioSource MissionClear;

    public string ActualVersion;
    public string GameVersion;

    public static string sActualVersion;

    float game;

    public override void OnConnectedToMaster() 
    {
        Debug.Log("Conectado al Servidor Master");
        PhotonNetwork.JoinLobby();
        canDownload = true;
        downloading = PlayerPrefs.GetFloat("Downloaded");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        canDownload = false;
        PlayerPrefs.SetFloat("Downloaded", downloading);
    }

    void Update()
    {
        sActualVersion = ActualVersion;

        downloadI.fillAmount = downloading / 2500;

        if (timer != 0) {timer += Time.deltaTime;}

        if (isDownloading)
        {
            Tiempo.text = "Tiempo: " + timer.ToString("0");
            roundTime = Mathf.Round(downloadTime);

            downloading++;
            timer += Time.deltaTime;
            downloadTime += Time.deltaTime;

            if (roundTime == 0)
            {
                tDownloading.text = "Descargando juego";
            }

            if (roundTime == 1)
            {
                tDownloading.text = "Descargando juego.";
            }

            if (roundTime == 2)
            {
                tDownloading.text = "Descargando juego..";
            }

            if (roundTime == 3)
            {
                tDownloading.text = "Descargando juego...";
            }

            if (roundTime == 4)
            {
                tDownloading.text = "Descargando juego";
                downloadTime = 0;
            }
        }

        if (downloading >= 2500)
        {
            StartCoroutine(GoToMenu());
            ActualVersion = GameVersion;
        }

        if (!canDownload) 
        {
            isDownloading = false;
            if (timer == 0)
            {
                unconnectedTimer += Time.deltaTime;
            }

            else
            {
                tDownloading.text = "Se ha producido un error. Reiniciando";
            }

            if (unconnectedTimer >= 15)
            {
                tDownloading.text = "No se ha podido conectar. Reiniciando...";
                unconnectedTimer = 0;
                StartCoroutine(ReloadRooms());
            }
        }

        if (downloaded == 1) {SceneManager.LoadScene("MainMenu");}

        else
        {
            unconnectedTimer = 0;
        }

        downloadButtonGO.interactable = canDownload;
    }

    

    void Start()
    {
        MissionClear.GetComponent<AudioSource>();

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        ActualVersion = PlayerPrefs.GetString("Version");
        CheckVersion();
        
        downloadI.fillAmount = 0;
    }

    private void CheckVersion()
    {
        if (ActualVersion == GameVersion)
        {
            downloaded = PlayerPrefs.GetFloat("Download Game");
        }

        else
        {
            downloaded = 0;
            PlayerPrefs.SetFloat("Download Game", downloaded);
        }
    }

    public void DownloadButton()
    {
        isDownloading = !isDownloading;
        if (!isDownloading)
        {
            tDownloading.text = "Descarga pausada";
        }
    }

    private IEnumerator GoToMenu()
    {
        isDownloading = false;
        MissionClear.Play();
        yield return new WaitForSeconds(1f);
        downloaded = 1;
        PlayerPrefs.SetFloat("Downloaded", game);
        PlayerPrefs.SetString("Version", ActualVersion);
        PlayerPrefs.SetFloat("Download Game", downloaded);
    }

    public void Esc()
    {
        StartCoroutine(CloseGame());
    }

    public IEnumerator ReloadRooms()
    {
        PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        tDownloading.text = "";
    }

    public IEnumerator CloseGame()
    {
        tDownloading.text = "Desconectando...";
        PlayerPrefs.SetFloat("Downloaded", downloading);
        PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(1f);
        PhotonNetwork.Disconnect();
        tDownloading.text = "Cerrando...";
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}