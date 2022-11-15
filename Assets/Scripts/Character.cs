using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _animator;
    private float _moveSpeed = 4f;
    private bool _isWalking = true;

    //private bool _isAttacking = false;

    [SerializeField]
    private RoadManager RoadManagerComp;

    void Awake()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        handleAnimation();
    }

    void Move()
    {
        if (_isWalking)
        {
            _characterController.Move(Vector3.forward * _moveSpeed * Time.deltaTime);
        }
    }

    void handleAnimation() { }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("RoadSpawnTrigger"))
        {
            RoadManagerComp.MoveRoad();
        }
    }

    void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.name == "AttackTrigger")
        {
            //_isAttacking = true;
            _isWalking = false;
            _animator.SetBool("isAttacking", true);
        }
    }
}
