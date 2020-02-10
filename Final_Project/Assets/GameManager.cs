using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Photon.MonoBehaviour
{
    private string _userName = "will h";
    private float _respawn = 0f;
    private Transform spawn;
    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("v1");
    }

    public void JoinGame()
    {
        PhotonNetwork.JoinOrCreateRoom("GAM24", new RoomOptions() { MaxPlayers = 0 }, TypedLobby.Default);
    }

    public void Spawn()
    {
        PhotonNetwork.Instantiate("NetworkPlayer", new Vector3(10f, 3f, -10f), Quaternion.identity, 0);
    }

    public void OnConnectedToMaster()
    {
        Debug.Log("On Connected to master server.");

        JoinGame();
    }

    public void OnJoinedRoom()
    {
        Debug.Log("On Joined Room!");

        Spawn();
    }

    public void Respawn()
    {
        StartCoroutine(RespawnPlayer());
    }

    IEnumerator RespawnPlayer()
    {
        _respawn = 5f;

        while (_respawn > 0f)
        {
            _respawn -= Time.deltaTime;

            yield return null;
        }

        Spawn();
    }

    public void OnGUI()
    {
        GUILayout.BeginVertical();

        if(_respawn > 0f)
        {
            GUILayout.Button("Respawning in " + (int)_respawn + "sec");
        }


        foreach(PhotonPlayer player in PhotonNetwork.playerList)
        {
            GUILayout.Button(player.NickName + " : " + player.GetScore());
        }

        GUILayout.EndVertical();


        if(PhotonNetwork.connected == false)
        {
            GUILayout.BeginArea(new Rect(Screen.width/2f, Screen.height/2f, 300f, 150f));

            _userName = GUILayout.TextField(_userName);

            if( GUILayout.Button("Login") )
            {
                PhotonNetwork.player.NickName = _userName;

                Connect();
            }

            GUILayout.EndArea();
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
