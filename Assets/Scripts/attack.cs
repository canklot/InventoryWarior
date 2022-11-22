using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject AttackedObject;
    static HeathBarClass OtherHealthBar;

    void Start() { }

    void Update() { }

    void OnTriggerStay(Collider OtherCollider)
    {
        if (OtherCollider.CompareTag("Enemy"))
        {
            OtherHealthBar.TakeDamage(1);
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        Debug.Log(OtherCollider.name);
        if (OtherCollider.CompareTag("Enemy"))
        {
            OtherHealthBar = OtherCollider.GetComponent<HeathBarClass>();
        }
    }
}
