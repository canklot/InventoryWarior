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
            AttackedObject = this.transform.parent.gameObject;
            OtherHealthBar = OtherCollider.GetComponent<HeathBarClass>();
            // OtherHealthBar = AttackedObject.transform
            //    .Find("AttackTrigger")
            //    .GetComponent<HeathBarClass>();


            //  Animator AttackerAnimator = OtherCollider.GetComponent<Animator>();
            //  AttackerAnimator.SetBool("isAttacking", true);
        }
    }
}
