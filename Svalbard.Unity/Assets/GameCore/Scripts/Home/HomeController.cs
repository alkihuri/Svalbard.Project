using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject enteredObject = other.gameObject;
        if (enteredObject.GetComponent<ISpeaker>() != null)
            enteredObject.GetComponent<ISpeaker>().TurnOn();
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject leavedObject = other.gameObject;
        if (leavedObject.GetComponent<ISpeaker>() != null)
            leavedObject.GetComponent<ISpeaker>().TurnOff();
    }
}
