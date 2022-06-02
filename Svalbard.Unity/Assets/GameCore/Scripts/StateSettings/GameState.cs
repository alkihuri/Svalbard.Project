using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace StateSettings
{

    public enum State
    {
        connected,
        disconected,
        crushed
    }
    public abstract class GameState 
    {
        public State _currentState;
        public abstract GameState ApplyState();
    }

    public class GameIsConnected : GameState
    {
        public override GameState ApplyState()
        {
            _currentState = State.connected;
            return this;
        }
    }
    public class GameIsDisconnected : GameState
    {
        public override GameState ApplyState()
        {
            _currentState = State.disconected;
            return this;
        }
    }
    public class GameIsCrushed : GameState
    {
        public override GameState ApplyState()
        {
            _currentState = State.crushed;
            return this;
        }
    }

}
