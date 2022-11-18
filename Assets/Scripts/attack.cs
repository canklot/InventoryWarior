using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void Start() { }

    void Update() { }

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Enemy"))
        {
            HeathBarClass otherHealthBar = otherCollider.GetComponent<HeathBarClass>();
            otherHealthBar.TakeDamage(1);
        }
    }
}
