public class MoveState : MovementState
{
    private MoveStateConfig _config;
    public MoveState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.MoveStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
    }

    public override void Update()
    {
        base.Update();

        if (IsFinish())
        {
            switch(Data.TargetTransform.TypeTarget)
            {
                case TargetTransformCharacter.TypeTargets.Home:
                    StateSwitcher.SwitchState<RestState>();
                    break;

                case TargetTransformCharacter.TypeTargets.Work:
                    StateSwitcher.SwitchState<WorkerState>();
                    break;

                default:
                    StateSwitcher.SwitchState<RestState>();
                    break;
            }
        }
    }
}
