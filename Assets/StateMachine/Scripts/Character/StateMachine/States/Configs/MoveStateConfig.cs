using System;
using UnityEngine;

[Serializable]
public class MoveStateConfig
{
    [SerializeField, Range(0, 10)] private float _defaultSpeed = 3;
    [SerializeField, Range(0, 10)] private float _boostSpeed = 5;

    public float DefaultSpeed => _defaultSpeed;
    public float BoostSpeed => _boostSpeed;
}
