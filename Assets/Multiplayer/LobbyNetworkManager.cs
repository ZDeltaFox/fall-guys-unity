using UnityEngine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (PhotonView))]

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    public static bool isOnRoom;

    [Header ("Room")]
    [SerializeField] private TMP_InputField _roomInput;
    [SerializeField] private RoomItemUI _roomItemUIPrefab;
    [SerializeField] private Transform _roomListParent; 


    [Header ("Player")]
    [SerializeField] private RoomItemUI _playerItemUIPrefab;
    [SerializeField] private Transform _playerListParent;
    public static Transform playerListParent;
    //private PhotonView pv;


    [Header ("Status")]
    [SerializeField] private Text _statusField;
    [SerializeField] private Text _currentLocationText;
    [SerializeField] private TMP_Text _currentRoomText;
    [SerializeField] private TMP_Text _currentPlayersText;


    [Header ("Button")]
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private Button _createGameButton;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private GameObject _reloadMultiplayerButton;


    [Header ("Window")]
    [SerializeField] private GameObject _roomListWindow;
    [SerializeField] private GameObject _playerListWindow;
    [SerializeField] private GameObject _createRoomWindow;


    [Header ("Menu")]
    [SerializeField] private GameObject _loadingRoomScreen;
    [SerializeField] private GameObject _nameGameText;
 
    private List<RoomItemUI> _roomList = new List<RoomItemUI>();
    private List<RoomItemUI> _playerList = new List<RoomItemUI>();


    [Header ("Game")]
    public Text PlayerNumber;
    public Text PlayerCount;

    public static float MyPlayerNumberCounter;
    public static float PNC;

    public byte ActualNumberCounter;

    [Header ("Parameters")]
    public byte maxPlayers;
    public byte PlayerCounter;
    public static float SPlayerCounter;
    public static float PlayerNumberCounter;
    public byte MinPlayers;
    public bool isVisible;
    [SerializeField] private TMP_Text _isVisible;

    float timer;
    float timerq;
    public float maxTime;

    public GameObject ErrorPrefab;

    void Start()
    {
        playerListParent = _playerListParent;
        Connect();
        Initialize();
    }

    #region PhotonCallbacks

    private void Initialize()
    {
        _leaveRoomButton.interactable = false;
        _startGameButton.interactable = false;
        _createGameButton.interactable = true;

        _currentLocationText.color = Color.red;
        _loadingRoomScreen.SetActive(false);
    }

    public override void OnConnectedToMaster() 
    {
        Debug.Log("Conectado al Servidor Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if (_statusField == null) {return;}
        _statusField.text = "Disconnected";
    }

    public override void OnJoinedLobby()
    {
        _currentLocationText.text = "Connected";
        _currentLocationText.color = Color.green;
    }

    public override void OnJoinedRoom()
    {
        isOnRoom = true;
        _statusField.text = "Joined " + PhotonNetwork.CurrentRoom.Name;
        _currentLocationText.text = PhotonNetwork.CurrentRoom.Name;
        _currentRoomText.text = PhotonNetwork.CurrentRoom.Name;
        _leaveRoomButton.interactable = true;

        if (PhotonNetwork.IsMasterClient)
        {
            _createGameButton.interactable = false;
        }
        //UpdatePlayerList();
        Vector3 newPos = new Vector3(0, 0, 0);
        //pv = GetComponent<PhotonView>();
        GameObject newObject = PhotonNetwork.Instantiate(_playerItemUIPrefab.name, newPos, Quaternion.identity, 0, null);
        //pv.RPC("SetParent", RpcTarget.All, newObject);
        ShowWindow(false);

        _startGameButton.interactable = false;
        _createGameButton.interactable = false;

        _loadingRoomScreen.SetActive(true);
        _nameGameText.SetActive(false);

        //PlayerID._ID = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    /*[PunRPC]
    void SetParent(GameObject obj)
    {
        obj.transform.SetParent(_playerListParent.transform);
    }*/

    public override void OnLeftRoom()
    {
        isOnRoom = false;
        if (_statusField != null) 
        {
            _statusField.text = "Lobby";
        }

        if (_currentLocationText != null)
        {
            _currentLocationText.text = "Reloading multiplayer...";
            _currentLocationText.color = Color.red;
        }

        _leaveRoomButton.interactable = false;
        _startGameButton.interactable = false;
        _createGameButton.interactable = true;
        //UpdatePlayerList();

        ShowWindow(true);
        _loadingRoomScreen.SetActive(false);
        _nameGameText.SetActive(true);
    }

    /*public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }*/

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //UpdatePlayerList();
        timerq = -1f;
        timer = -1f;

        if (PlayerNumberCounter >= PlayerCounter + 1) {PlayerNumberCounter--;}

        //if (PlayerID._ID >= PlayerCounter + 1) {PlayerID._ID--;}
    }
    #endregion

    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        //Limpiar la lista de salas actual
        for (int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }

        _roomList.Clear();
        //Generar una nueva lista con informacion actualizada
        for (int i = 0; i < roomList.Count + 1; i++)
        {
            //Saltar salas vacias
            if (roomList[i].PlayerCount == 0) {continue;}

            RoomItemUI newRoomItem = Instantiate(_roomItemUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(_roomListParent);

            _roomList.Add(newRoomItem);
        }
    }

    /*private void UpdatePlayerList()
    {
        //Limpiar la lista de jugadores actual
        for (int i = 0; i < _playerList.Count; i++)
        {
            Destroy(_playerList[i].gameObject);
        }

        _playerList.Clear();

        if (PhotonNetwork.CurrentRoom == null) {return;}
        //Generar una nueva lista de jugadores
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            RoomItemUI newPlayerItem = Instantiate(_playerItemUIPrefab);

            newPlayerItem.transform.SetParent(_playerListParent);

            _playerList.Add(newPlayerItem);
        }
    }*/

    private void ShowWindow (bool isRoomList)
    {
        _roomListWindow.SetActive(isRoomList);
        _playerListWindow.SetActive(!isRoomList);
        _createRoomWindow.SetActive(isRoomList);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_roomInput.text) == false)
        {
            PhotonNetwork.CreateRoom(_roomInput.text, new RoomOptions() {MaxPlayers = maxPlayers, IsVisible = isVisible}, null);
        }

        timer = -1f;
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        timer = -1f;
        timerq = -1f;
    }

    public void Join() 
    {
        string roomName = _roomInput.text;
        PhotonNetwork.JoinRoom(roomName);
    }

    public void Visible() 
    {
        isVisible = !isVisible;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnBackToMainMenuPressed()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnReloadPressed()
    {
        StartCoroutine(ReloadRooms());
    }

    public IEnumerator ReloadRooms()
    {
        _currentLocationText.text = "Reloading multiplayer...";
        _currentLocationText.color = Color.red;
        Buttons.chatActived = false;
        //PhotonNetwork.LeaveRoom();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.Disconnect();
        yield return new WaitForSeconds(0.25f);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnStartGamePressed()
    {
        if (PlayerCounter >= MinPlayers)
        {
            PhotonNetwork.LoadLevel("RoomSelector");
            Rounds._thisRound = 1;

            Buttons.isInLoad = true;
        }

        else
        {
            Instantiate(ErrorPrefab);
            Error.stError = "<size=96><b>" + (MinPlayers - PlayerCounter) + "<size=72><b> player " + "left";
        }
    }

    private void FixedUpdate() 
    {
        if (isVisible) {_isVisible.text = "Visible";}
        else {_isVisible.text = "No visible";}
        if (Input.GetKey("left ctrl") && Input.GetKey("r") || Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(ReloadRooms());
            connectTimer = 0;
        }

        if (PhotonNetwork.CurrentRoom != null)
        {
            PlayerCounter = PhotonNetwork.CurrentRoom.PlayerCount;
            SPlayerCounter = PlayerCounter;
        }

        if (timer <= maxTime) 
        {
            PlayerNumber.text = "Player: " + PlayerNumberCounter;
            MyPlayerNumberCounter = PlayerNumberCounter;
        }        
        
        if (timerq <= maxTime) {PlayerNumberCounter = PlayerCounter;}

        if (PlayerNumberCounter == 1) {_startGameButton.interactable = true;}

        timer += Time.deltaTime;

        PlayerCount.text = "Players: " + PlayerCounter + " / " + maxPlayers;
        
        ActualNumberCounter = PlayerCounter;

        if (Buttons.stimer >= Buttons.smaxTime)
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (_currentLocationText.text == "Reloading multiplayer..." || _currentLocationText.text == "Loading multiplayer...")
        {
            connectTimer += Time.deltaTime;
            if (connectTimer >= 10)
            {
                StartCoroutine(ReloadRooms());
                connectTimer = 0;
            }
        }

        else {connectTimer = 0;}

        if (_currentLocationText.text == "Reloading multiplayer...") {_reloadMultiplayerButton.SetActive(true);}
        else {_reloadMultiplayerButton.SetActive(false);}

        if (PhotonNetwork.IsMasterClient) {_startGameButton.interactable = true;}
        else {_startGameButton.interactable = false;}
    }

    float connectTimer;
}