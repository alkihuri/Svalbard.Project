using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour, ISpeaker
{
    [SerializeField] AudioSource _audio; // можно конечно ссылку на Recorder 
                                         // и оключать передачу, но так надежне и проще

    private void Start()
    {
        _audio = GetComponentInChildren<AudioSource>();
        TurnOff();
    }

    public void TurnOff()
    {
        _audio.mute = true;
    }

    public void TurnOn()
    {
        _audio.mute = true;
    }

     
}
