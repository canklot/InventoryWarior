using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 6.0f;
    [SerializeField] private float _jumpForce = 200;

    private CharacterController _characterController;
    private Animator _animator;
    void Awake()
    {

        _characterController = gameObject.GetComponent<CharacterController>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        _characterController.Move(Vector3.forward * Time.deltaTime);

        //_rigidBody.velocity = characterVelocity;

    }
    void HandleGravity()
    {
        if (Grounded)
        {
            if (_verticalVelocity < 0.0f)
            {
                _verticalVelocity = 0.0f;
            }
        }
        if (IsJumping)
        {
            _verticalVelocity = 0f;
        }
        else if (_verticalVelocity < _terminalVelocity)
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
    }

}
