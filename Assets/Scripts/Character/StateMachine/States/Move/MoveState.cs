using UnityEngine.InputSystem;

public abstract class MoveState : MovementState
{
    protected MoveStateConfig _config;
    public MoveState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.MoveStateConfig;

    public override void Update()
    {
        base.Update();

        if (IsOnTarget())
        {
            switch (Data.TargetTransform.TypeTarget)
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

    protected override void AddInputActionsCallback()
    {
        base.AddInputActionsCallback();

        Input.Movement.Boost.started += OnBoostPressed;
        Input.Movement.Boost.canceled += OnBoostUnpressed;
    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();

        Input.Movement.Boost.started -= OnBoostPressed;
        Input.Movement.Boost.canceled -= OnBoostUnpressed;
    }

    private void OnBoostPressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<BoostSpeedState>();

    private void OnBoostUnpressed(InputAction.CallbackContext context) => StateSwitcher.SwitchState<DefaultSpeedState>();
}