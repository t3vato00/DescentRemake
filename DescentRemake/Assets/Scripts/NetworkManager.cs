using UnityEngine;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

	// Use this for initialization
	public Camera standbyCamera;
	public float respawnTimer = 0;
    bool connecting = false;
	SpawnSpot[] spawnSpots;

    List<string> chatMessages;
    int maxChatMessages = 10;

<<<<<<< HEAD
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
        PhotonNetwork.player.name = PlayerPrefs.GetString("Username", "Awesome player");
        chatMessages = new List<string>();

	}
=======
    private Text NameText;
    private InputField NameInput;
    private Button ConnectMP;



    public void ConnectMPButton()
    {
        Connect();

    }
    void Start()
    {
        spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
        PhotonNetwork.player.name = PlayerPrefs.GetString("Username", "Awesome player");
        chatMessages = new List<string>();

        NameText = GameObject.Find("NameText").GetComponent<Text>();
        NameInput = GameObject.Find("NameInput").GetComponent<InputField>();
        ConnectMP = GameObject.Find("ConnectMP").GetComponent<Button>();
 



    }
>>>>>>> develop

    void OnDestroy()
    {
        PlayerPrefs.SetString("Username", PhotonNetwork.player.name);
       /* Hashtable props = new Hashtable();
        props["asddsaddsa"] = 2;
        PhotonNetwork.player.SetCustomProperties(props);*/
    }

    public void AddChatMessage(string m)
    {
        if (chatMessages.Count >= maxChatMessages)
        {
            chatMessages.RemoveAt(0);
        }
        chatMessages.Add(m);
    }
	
	void Connect(){
		//PhotonNetwork.offlineMode = true;
		PhotonNetwork.ConnectUsingSettings ("DescentRemake");
        

<<<<<<< HEAD
	}
	void Update(){
		if (respawnTimer > 0) {
			respawnTimer -= Time.deltaTime;
			
			if (respawnTimer <= 0) {
				SpawnMyPlayer ();
			}
		}
	}

	void OnGUI(){
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());

        if (PhotonNetwork.connected == false && connecting == false )
=======
    void Connect()
    {
        //PhotonNetwork.offlineMode = true;
        PhotonNetwork.ConnectUsingSettings("DescentRemake");

        NameInput.enabled = false;
        NameInput.GetComponent<CanvasGroup>().alpha = 0;

        NameText.enabled = false;
        NameText.GetComponent<CanvasGroup>().alpha = 0;

        ConnectMP.enabled = false;
        ConnectMP.GetComponent<CanvasGroup>().alpha = 0;



    }
    void Update()
    {
        if (respawnTimer > 0)
>>>>>>> develop
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Username: ");
            PhotonNetwork.player.name = GUILayout.TextField(PhotonNetwork.player.name);
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Multiplayer"))
            {
                Connect();
            }
            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }

        if (PhotonNetwork.connected == true && connecting == false)
        {
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

<<<<<<< HEAD
            foreach(string msg in chatMessages){
                GUILayout.Label(msg);
            }
=======
            PhotonNetwork.player.name = NameInput.text;
            if (NameInput.text.Length > 0)
            {
                ConnectMP.enabled = true;


                if (Input.GetKeyDown(KeyCode.Return))
                {
                    ConnectMPButton();
                }

                 

            }
            else
                ConnectMP.enabled = false;


        }
>>>>>>> develop

            GUILayout.EndVertical();
            GUILayout.EndArea();
        }
	}
	void OnJoinedLobby(){
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		Debug.Log ("OnJoinedRoom");
        connecting = false;
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer(){
        AddChatMessage("Spawning player: " + PhotonNetwork.player.name);
        
<<<<<<< HEAD
		if (spawnSpots == null) {
			Debug.LogError ("Broken");
			return;
		}
		SpawnSpot mySpawnSpot = spawnSpots [Random.Range (0, spawnSpots.Length)];
		GameObject myPlayerGO = (GameObject)
		PhotonNetwork.Instantiate ("Player", mySpawnSpot.transform.position, transform.rotation, 0);
		//came.enabled = false;
		myPlayerGO.GetComponent<NetworkCharacterMovement> ().enabled = true;
        myPlayerGO.GetComponent<PlayerMovement> ().enabled = true;
        myPlayerGO.AddComponent<Camera>();
        //Instantiate(gameObject.AddComponent<Camera>(), transform.position, Quaternion.identity) as Camera;

        //myPlayerGO.GetComponent<PlayerControl> ().enabled = true;
        //myPlayerGO.GetComponentInChildren<PlayerShooting> ().enabled = true;
        //myPlayerGO.GetComponentInChildren<PlayerHealth> ().enabled = true;
=======
        SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
        GameObject myPlayerGO = (GameObject)
        PhotonNetwork.Instantiate("Player", mySpawnSpot.transform.position, transform.rotation, 0);
        myPlayerGO.GetComponent<NetworkCharacterMovement>().enabled = true;
        myPlayerGO.GetComponent<MouseMovement>().enabled = true;
        myPlayerGO.GetComponent<ChatManager>().enabled = true;

        myPlayerGO.GetComponent<PlayerMovement>().enabled = true;

        cameras = myPlayerGO.GetComponentsInChildren<Camera>();
        foreach (Camera child in cameras)
        {
            child.enabled = true;
        }
        myPlayerGO.GetComponent<PlayerShoot>().enabled = true;
        myPlayerGO.GetComponent<FiringWeapons>().enabled = true;
        //myPlayerGO.GetComponent<PlayerSpotlight>().enabled = true;
       // myPlayerGO.GetComponent<UIController>().enabled = true;


        //myPlayerGO.GetComponentInChildren<> ().enabled = true;
>>>>>>> develop



    }

<<<<<<< HEAD
}
=======





}
>>>>>>> develop
