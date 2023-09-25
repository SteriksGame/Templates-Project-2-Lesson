using System;
using UnityEngine;

[Serializable]
public class RestStateConfig
{
    [SerializeField] private float _timeToRest = 3;

    public float TimeToRest => _timeToRest;
}
