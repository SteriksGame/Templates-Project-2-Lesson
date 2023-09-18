using System;
using UnityEngine;

[Serializable]
public class MoveStateConfig
{
    [SerializeField, Range(0, 10)] private float _speed = 3;

    public float Speed => _speed;
}
