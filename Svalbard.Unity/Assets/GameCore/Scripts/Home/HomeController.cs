using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.GetComponent<PlayerAudioController>())
            enteredObject.GetComponent<ISpeaker>().TurnOn();
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject leavedObject = other.gameObject;
        if (leavedObject.GetComponent<PlayerAudioController>())
            leavedObject.GetComponent<ISpeaker>().TurnOff();
    }
}
