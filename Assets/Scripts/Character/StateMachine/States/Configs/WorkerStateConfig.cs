using System;
using UnityEngine;

[Serializable]
public class WorkerStateConfig
{
    [SerializeField] private float _timeToWork = 3;

    public float TimeToWork => _timeToWork;
}
