using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent _player; 
    private float _vertical;
    private float _horizontal;
    private Vector3 _destinationPoint;
    private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _destinationPoint = transform.position;
        _player = GetComponent<NavMeshAgent>();
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_photonView.IsMine)
            return;

        InputDataHandler();  
        _player.SetDestination(_destinationPoint);
    }

    private void ThirdPersonControl()
    {
        if (!_player.isOnNavMesh)
            return;

        _destinationPoint = transform.position + transform.forward * _vertical + transform.right * _horizontal;
    }
     

    private void InputDataHandler()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
    }
     

}
