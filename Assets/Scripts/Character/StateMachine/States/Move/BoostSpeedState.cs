public class BoostSpeedState : MoveState
{
    public BoostSpeedState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.BoostSpeed;
    }
}