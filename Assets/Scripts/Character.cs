using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    private int _isWalkingHash;

    void Awake()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");

    }

    void Update()
    {
        Move();
        handleAnimation();
    }

    void Move()
    {
        if (Input.GetKey("d"))
        {
            print("D key was pressed");
        }
        _characterController.Move(Vector3.forward * Time.deltaTime);

    }

    void handleAnimation()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);

        //_animator.SetBool("isWalking", true);
    }
}
