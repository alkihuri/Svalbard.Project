using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.Instantiate("Player", Vector3.zero,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
