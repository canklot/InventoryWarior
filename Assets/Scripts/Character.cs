using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    InputController inputControllerIns;

    private bool _isGrounded;
    bool isMoventPressed;
    int isWalkingHash;

    Vector3 currentMovementInput;
    Vector2 currentMovement;

    void Awake()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
        inputControllerIns = new InputController();

        isWalkingHash = Animator.StringToHash("isWalking");

        inputControllerIns.CharacterControls.Move.started += onMovementInput;
        inputControllerIns.CharacterControls.Move.canceled += onMovementInput;
        inputControllerIns.CharacterControls.Move.performed += onMovementInput;
    }

    void OnEnable()
    {
        inputControllerIns.CharacterControls.Enable();
    }

    void OnDisable()
    {
        inputControllerIns.CharacterControls.Disable();
    }

    void Start() { }

    void Update()
    {
        Move();
        handleAnimation();
    }

    void Move()
    {
        //_characterController.Move((Vector3.forward * Time.deltaTime));
        _characterController.Move(new Vector3(Vector3.forward, currentMovement));
        //(Vector3.forward * Time.deltaTime)+(currentMovement * Time.deltaTime));
    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.y = currentMovementInput.y;
        isMoventPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    void handleAnimation()
    {
        bool isWalking = _animator.GetBool(isWalkingHash);

        if (isMoventPressed && !isWalking)
        {
            _animator.SetBool("isWalking", true);
        }
        else if (!isMoventPressed && isWalking)
        {
            _animator.SetBool("isWalking", false);
        }
    }
}
