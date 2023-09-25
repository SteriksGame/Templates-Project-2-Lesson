public class DefaultSpeedState : MoveState
{
    public DefaultSpeedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.DefaultSpeed;
    }
}

