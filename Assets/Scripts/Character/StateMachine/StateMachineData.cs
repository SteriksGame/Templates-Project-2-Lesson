using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineData
{
    public TargetTransformCharacter TargetTransform;

    public bool IsBoostInput;
    public float TimeToState;

    private float _speed;

    public float Speed
    {
        get => _speed;
        set
        {
            if (_speed < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
}
