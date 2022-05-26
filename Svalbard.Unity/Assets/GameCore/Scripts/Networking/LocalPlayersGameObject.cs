using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayersGameObject : MonoBehaviour
{

    [SerializeField] PhotonView _photonView;
    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponentInParent<PhotonView>();
        TurnOffGameObject();
    }
    public void TurnOffGameObject()
    {
         gameObject.SetActive(_photonView.IsMine);
    }
}
