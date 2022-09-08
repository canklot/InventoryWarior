using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private CharacterController _characterController;
    private Animator _animator;
    private float _moveSpeed = 4f;
    private int _isWalkingHash;
    [SerializeField] private RoadManager RoadManagerComp;


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
        if (Input.GetKey("d"))
        {
            print("D key was pressed");
        }
        _characterController.Move(Vector3.forward * _moveSpeed * Time.deltaTime);

    }

    void handleAnimation()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        RoadManagerComp.MoveRoad();
    }

}
