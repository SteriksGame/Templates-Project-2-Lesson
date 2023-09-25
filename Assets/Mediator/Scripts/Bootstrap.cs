using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Mediator _mediator;

    private void Awake()
    {
        PlayerInput input = new PlayerInput();

        PlayerCharacteristic playerCharacteristic = new PlayerCharacteristic(input);

        _mediator.Initialized(playerCharacteristic);
    }
}
