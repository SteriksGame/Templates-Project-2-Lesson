using UnityEngine;

public abstract class ActionState : MovementState
{
    protected ActionState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Update()
    {
        base.Update();

        float changeTimeToState = Data.TimeToState - Time.deltaTime;
        if (IsOnTarget() && changeTimeToState > 0)
        {
            Data.TimeToState = changeTimeToState;
            return;
        }
        Data.TimeToState = 0;

        if (Input.Movement.Boost.IsPressed())
            StateSwitcher.SwitchState<BoostSpeedState>();
        else
            StateSwitcher.SwitchState<DefaultSpeedState>();
    }
}
