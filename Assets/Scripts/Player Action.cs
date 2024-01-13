using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerAction : MonoBehaviour
{
    PlayerControls playerControls;
    private Transform _cameraTransform;
    public CharacterController characterController;
    private bool _isSprintPressed, _isJumpPressed, _isSprinting, _isRunning, _isMovePressed,
    _isAiming, _isShooting, _isGrenadeGettingThrown, _isReloading, _reloadStarted, _isCrouching, _bombWaiting, _isJumping;
    public bool isReloading => _isReloading;
    public bool isShooting => _isShooting;
    public bool isJumping => _isJumpPressed;
    public bool isJumpPressed => _isJumpPressed;
    public bool isRunning => _isRunning;
    public bool isSprinting => _isSprinting;
    public bool isCrouching => _isCrouching;
    public bool isAiming => _isAiming;
    private float _sprintSpeed = 8.0f, _moveSpeed = 5.0f, _jumpPower = 5f, _reloadCompletionTime = 1f, _shootingTime;
    public Vector3 moveVector;
    private GroundController _groundController;
    public GroundController groundController => _groundController;
    [SerializeField] private float _rotationSpeed = 15f;
    [Inject] Gravity gravity;
    private Weapon _weapon;

    //[SerializeField] CinemachineVirtualCamera tpsCamera;
    //[SerializeField] CinemachineVirtualCamera aimCamera;

    private void Awake()
    {
        playerControls = new PlayerControls();
        characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;
        _groundController = GetComponent<GroundController>();
        _weapon = GetComponentInChildren<Weapon>();


        playerControls.Player.Movement.started += HandleMovementInput;
        playerControls.Player.Movement.performed += HandleMovementInput;
        playerControls.Player.Movement.canceled += HandleMovementInput;
        playerControls.Player.Sprint.started += HandleSprintInput;
        playerControls.Player.Sprint.canceled += HandleSprintInput;
        playerControls.Player.Jump.started += HandleJumpInput;
        playerControls.Player.Jump.canceled += HandleJumpInput;
        //_playerControls.Player.Aim.started += HandleAim;
        //_playerControls.Player.Aim.canceled += HandleAim;
        playerControls.Player.Shoot.started += HandleShoot;
        playerControls.Player.Shoot.canceled += HandleShoot;
        playerControls.Player.Reload.started += HandleReload;
        //_playerControls.Player.Throw.started += HandleGrenade;
        //_playerControls.Player.Throw.canceled += HandleGrenade;
        //_playerControls.Player.Crouch.started += HandleCrouch;
        //_playerControls.Player.Crouch.canceled += HandleCrouch;
    }

    private void Update()
    {
        RotatePlayer();
        Move();
        Jump();
        gravity.ApplyGravity();
    }

    private void HandleReload(InputAction.CallbackContext context)
    {
        if (context.started && !_isReloading)
        {
            _isReloading = true;
            StartReload();
        }
    }
    private void HandleSprintInput(InputAction.CallbackContext context)
    {
        _isSprintPressed = context.ReadValueAsButton();
    }
    private void HandleGrenade(InputAction.CallbackContext context)
    {
        //if (context.started && _inventory.grenadeAmount > 0)
        //{
        //    isGrenadeGettingThrown = true;
        //}
        //else if (context.canceled)
        //{
        //    isGrenadeGettingThrown = false;
        //}
    }
    private void HandleMovementInput(InputAction.CallbackContext context)
    {

        moveVector.x = context.ReadValue<Vector2>().x;
        moveVector.z = context.ReadValue<Vector2>().y;
        _isMovePressed = moveVector.x != 0 || moveVector.z != 0;

    }
    private void HandleJumpInput(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
    }
    private void HandleAim(InputAction.CallbackContext context)
    {
        _isAiming = context.ReadValueAsButton();
    }
    private void HandleShoot(InputAction.CallbackContext context)
    {
        if (context.started && _weapon.ammoInMagazine > 0 && !isReloading)
        {
            _isShooting = true;
            _weapon.Shoot();
        }
        else if (context.canceled)
        {
            _isShooting = false;
        }
    }
    private void HandleCrouch(InputAction.CallbackContext context)
    {
        _isCrouching = context.ReadValueAsButton();
    }

    private void Move()
    {
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * moveVector.z + right * moveVector.x).normalized;
        Vector3 moveDirection = desiredMoveDirection * (_isSprintPressed ? _sprintSpeed : _moveSpeed);

        characterController.Move(moveDirection * Time.deltaTime);

        _isSprinting = _isSprintPressed;
        _isRunning = _isMovePressed;
    }

    private void Jump()
    {
        _isJumping = false;
        if (_groundController.isGrounded)
        {
            //_animator.SetBool("isJumping", false);
            if (_isJumpPressed)
            {
                _isJumping = true;
                moveVector.y = _jumpPower;
                //_animator.SetBool("isJumping", true);
            }
        }
    }

    private void RotatePlayer()
    {
        Quaternion rotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private void StartReload()
    {
        Invoke("CompleteReload", _reloadCompletionTime);
    }

    private void CompleteReload()
    {
        if (_isReloading)
        {
            _weapon.Reload();
        }
        _isReloading = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
