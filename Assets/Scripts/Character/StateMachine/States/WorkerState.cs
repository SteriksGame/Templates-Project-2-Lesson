using UnityEngine;

public class WorkerState : MovementState
{
    private WorkerStateConfig _config;
    public WorkerState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WorkerStateConfig;

    public override void Enter()
    {
        base.Enter();

        Data.TimeToState = _config.TimeToWork;
    }

    public override void Update()
    {
        base.Update();

        if (IsFinish() && Data.TimeToState > 0)
        {
            Data.TimeToState -= Time.deltaTime;
            return;
        }

        Data.TargetTransform = _character.TransformHome;
        StateSwitcher.SwitchState<MoveState>();
    }
}
