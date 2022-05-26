using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOutput : MonoBehaviour
{
    [SerializeField] Joystick _joystik;
    // Update is called once per frame
    private void Start()
    {
        _joystik = GetComponentInChildren<Joystick>();
    }
    void Update()
    {
        UniversalUIHandler.Instance.VERTICAL = _joystik.Vertical;
        UniversalUIHandler.Instance.HORIZONTAL = _joystik.Horizontal;
    }
}
