using UnityEngine;

public class RestState : MovementState
{
    private RestStateConfig _config;
    public RestState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RestStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.TimeToState = _config.TimeToRest;
    }

    public override void Update()
    {
        base.Update();

        if (IsFinish() && Data.TimeToState > 0)
        {
            Data.TimeToState -= Time.deltaTime;
            return;
        }

        Data.TargetTransform = _character.TransformWork;
        StateSwitcher.SwitchState<MoveState>();
    }
}
