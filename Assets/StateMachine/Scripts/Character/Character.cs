using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterConfig _config;

    [Space]
    [SerializeField] private TargetTransformCharacter _transformHome;
    [SerializeField] private TargetTransformCharacter _transformWork;

    private PlayerInput _input;
    private CharacterStateMachine _stateMachine;
    private CharacterController _controller;

    public PlayerInput Input => _input;
    public CharacterController Controller => _controller;
    public TargetTransformCharacter TransformHome => _transformHome;
    public TargetTransformCharacter TransformWork => _transformWork;
    public CharacterConfig Config => _config;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = new PlayerInput();
        _stateMachine = new CharacterStateMachine(this);
    }

    private void Update()
    {
        _stateMachine.HandleInput();

        _stateMachine.Update();
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();
}