using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    void Start() { }

    void Update() { }

    void OnTriggerStay(Collider otherCollider)
    {
        Debug.Log("OnTriggerStay");
        if (otherCollider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            HeathBarClass otherHealthBar = otherCollider.GetComponent<HeathBarClass>();
            otherHealthBar.TakeDamage(1);
        }
    }
}
