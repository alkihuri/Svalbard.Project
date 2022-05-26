using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalUIHandler : MonoSinglethon<UniversalUIHandler>
{
    float _vertical;
    float _horizontal; 
    public float VERTICAL
    {
        get
        {
            return Mathf.Clamp(_vertical, -1, 1);
        }
        set
        {
            _vertical = value;
        }
    }
    public float HORIZONTAL
    {
        get
        {
            return Mathf.Clamp(_horizontal, -1, 1);
        }
        set
        {
            _horizontal = value;
        }
    } 
}
