using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
using Photon.Realtime;
using StateSettings;

namespace Networking
{

    public class LobbyManager : MonoBehaviourPunCallbacks
    {

        List<Photon.Realtime.Room> roomList;

        private void Start()
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Nickname");
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.AutomaticallySyncScene = false;

            GameStateMachine.Instance.PHOTON_VIEW = gameObject.AddComponent<PhotonView>();
            GameStateMachine.Instance.SetState(new GameIsConnected().ApplyState());  // пример
        }


        public override void OnConnectedToMaster()
        {
            Debug.Log("Присоеденяемся...");
            PhotonNetwork.JoinLobby();
        }
        public override void OnJoinedLobby()
        {
            Debug.Log("Входим в лоби...");
            RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
            PhotonNetwork.JoinOrCreateRoom("Svalbard", roomOptions, TypedLobby.Default);
        }

        public override void OnCreatedRoom()
        {
            Debug.Log("Ты первый на Свальбарде!");
            PhotonNetwork.JoinRoom("Svalbard");
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("Тебя уже ждут на Свальбарде!");
            PhotonNetwork.LoadLevel("Svalbard");
        }

    }
}