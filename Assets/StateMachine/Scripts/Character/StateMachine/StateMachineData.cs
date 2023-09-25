using System;

public class StateMachineData
{
    public TargetTransformCharacter TargetTransform;

    public float _timeToState;

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
    public float TimeToState
    {
        get => _timeToState;
        set
        {
            if(_timeToState < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _timeToState = value;
        }
    }
}
