using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;

    private float _currentSpeed;
    private CharacterController _charController;
    private float _initialYPosition;

    private void Awake()
    {
        _charController = GetComponent<CharacterController>();
        _initialYPosition = transform.localPosition.y;
    }

    public void Move(Vector3 inputVector)
    {
        if (inputVector == Vector3.zero)
        {
            if (_currentSpeed > 0)
            {
                _currentSpeed -= deceleration * Time.deltaTime;
                _currentSpeed = Mathf.Max(_currentSpeed, 0);
            }
        }
        else
        {
            _currentSpeed = Mathf.Lerp(_currentSpeed, moveSpeed, Time.deltaTime * acceleration);
        }

        Vector3 movement = inputVector.normalized * _currentSpeed * Time.deltaTime;
        _charController.Move(movement);
        transform.position = new Vector3(transform.position.x, _initialYPosition, transform.position.z);
    }
}
