using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class PlayerController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    private PlayerInputHandler _inputHandler;
    private PlayerMovement _movement;

    private void Awake()
    {
        _inputHandler = GetComponent<PlayerInputHandler>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        Vector3 inputVector = _inputHandler.GetInput(forwardKey, backwardKey, leftKey, rightKey);
        _movement.Move(inputVector);
    }
}

