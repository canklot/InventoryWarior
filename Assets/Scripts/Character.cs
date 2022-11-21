using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    private float _moveSpeed = 4f;
    private bool _isWalking = true;

    void Awake()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        MovementLogic();
    }

    void MovementLogic()
    {
        if (_isWalking)
        {
            _characterController.Move(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    public void Stop()
    {
        _isWalking = false;
    }

    public void Move()
    {
        _isWalking = true;
    }
}
