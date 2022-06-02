using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StateSettings
{
    public class GameStateMachine : MonoSinglethon<GameStateMachine>
    {
        public object _currentState;

        PhotonView _photonView; 

        Dictionary<State, UnityEvent> _eventList = new Dictionary<State, UnityEvent>();

        Dictionary<string, State> _stateBuffer = new Dictionary<string, State>();

        public PhotonView PHOTON_VIEW 
        {
            set
            {
                _photonView = value;
            }
        }

        public void EventsMaping()
        {

            UnityEvent connectedEvent = new UnityEvent();
            connectedEvent.AddListener(ConnectToserver);
            _eventList.Add(State.connected, connectedEvent);

            UnityEvent disconnectedEvent = new UnityEvent();
            disconnectedEvent.AddListener(Disconect);
            _eventList.Add(State.disconected, disconnectedEvent);

            UnityEvent crushEvent = new UnityEvent();
            disconnectedEvent.AddListener(Crush);
            _eventList.Add(State.crushed, crushEvent);
        }

        private void Awake()
        {
            EventsMaping();
        }
 

        [PunRPC]
        public bool SetState(GameState stateToSet)
        {

            _currentState = stateToSet.ApplyState();
            if (!(_currentState is GameState))
            {
                Debug.LogError("нет такого состояния:( ");
                return false;
            }

            var gameState = (GameState)_currentState;
            var enumstate = gameState._currentState;

            _stateBuffer.Add(Time.time.ToString(), enumstate); // запись состояний


            if (_eventList.ContainsKey(enumstate))
                _eventList[enumstate].Invoke();
            else
                Debug.LogError("нет такого состояния : " + enumstate.ToString());

            return _eventList.ContainsKey(enumstate);
        }

        public void SyncSetState(GameState stateToSet)
        {
            _photonView.RPC("SetState", Photon.Pun.RpcTarget.All, stateToSet);
        }


        public void ConnectToserver()
        {
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("Присоеденяймся...");
        }
        public void Disconect()
        {
            PhotonNetwork.Disconnect();
            Debug.Log("Разрываем соеденеие...");
        }
        public void Crush()
        {
            PhotonNetwork.Reconnect();
            Debug.Log("Переподключаемся...");
        }
    }
}