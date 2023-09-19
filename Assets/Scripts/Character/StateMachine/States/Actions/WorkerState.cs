public class WorkerState : ActionState
{
    private WorkerStateConfig _config;
    public WorkerState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WorkerStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.TimeToState = _config.TimeToWork;
    }

    public override void Exit() 
    { 
        base.Exit();

        Data.TargetTransform = _character.TransformHome;
    }
}
