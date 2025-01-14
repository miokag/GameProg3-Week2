using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSingleResponsibility : MonoBehaviour
{
    //For readability
    [Header("Movement")]
    [Tooltip("Horizontal Speed")]
    [SerializeField] private float moveSpeed;
    [Tooltip("Rate of Change for Movement Speed")]
    [SerializeField] private float acceleration;
    [Tooltip("Deceleration Rate When No Input")]
    [SerializeField] private float deceleration;

    [Header("Controls")] [Tooltip("Use Keys to Move")]
    [SerializeField] private KeyCode forwardKey = KeyCode.W;
    [SerializeField] private KeyCode backwardKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Effects")] 
    [SerializeField] private ParticleSystem partSys;
    
    [Header("Collision")]
    [SerializeField] private LayerMask wallLayer;
    
    private Vector3 _inputVector;
    private float _currentSpeed;
    private CharacterController _charController;
    private float _initialYPosition;

    private void Awake()
    {
        _charController = GetComponent<CharacterController>();
        _initialYPosition = _charController.transform.localPosition.y;
    }

    void Update()
    {
        HandleInput();
        Move(_inputVector);
    }
    
    private void HandleInput()
    {
        float xInput = 0;
        float zInput = 0;
        
        if(Input.GetKey(forwardKey)) zInput++;
        else if(Input.GetKey(backwardKey)) zInput--;
        if(Input.GetKey(leftKey)) xInput--;
        else if(Input.GetKey(rightKey)) xInput++;
        
        _inputVector = new Vector3(xInput, 0, zInput);
    }
    
    private void Move(Vector3 _inputVector)
    {
        if (_inputVector == Vector3.zero)
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
        
        Vector3 movement = _inputVector.normalized * _currentSpeed * Time.deltaTime;
        _charController.Move(movement);
        transform.position = new Vector3(transform.position.x, _initialYPosition, transform.position.z);
    }

    private void PlayAudioClip()
    {
        audioSource.Play();
    }

    private void PlayParticleEffect()
    {
        Debug.Log("Play Particle Effect");
        partSys.Play();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Check if collided object's layer is in the wallLayer layermask
        if ((wallLayer.value & (1 << hit.gameObject.layer)) > 0)
        {
            PlayAudioClip();
            PlayParticleEffect();
        }
    }
}
