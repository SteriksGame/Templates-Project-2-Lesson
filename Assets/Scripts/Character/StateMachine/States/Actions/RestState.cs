public class RestState : ActionState
{
    private RestStateConfig _config;
    public RestState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RestStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.TimeToState = _config.TimeToRest;
    }

    public override void Exit() 
    { 
        base.Exit();

        Data.TargetTransform = _character.TransformWork;
    }
}
