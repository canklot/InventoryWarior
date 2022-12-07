using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Always make enemy attack range longer than player stop range
    GameObject ParentObject;
    Animator ParentAnimator;
    int RemainingOtherHp;
    HealthBarClass OtherHealthBar;

    [SerializeField]
    private int AttackPower;

    void OnEnable()
    {
        ParentObject = gameObject.transform.parent.gameObject;
        ParentAnimator = ParentObject.GetComponent<Animator>();
    }

    void Update() { }

    void OnTriggerStay(Collider OtherCollider)
    {
        if (OtherCollider.gameObject == ParentObject.gameObject)
        {
            return;
        }
        if (OtherCollider.CompareTag("Enemy") | OtherCollider.CompareTag("Player"))
        { //change enemyhp with otherhp
            DealDamageToOther();
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        if (OtherCollider.gameObject == ParentObject.gameObject)
        {
            // Debug.Log("same");
            return;
        }
        if (OtherCollider.CompareTag("Enemy") | OtherCollider.CompareTag("Player"))
        {
            OtherHealthBar = OtherCollider.GetComponent<HealthBarClass>();
            ParentAnimator.SetBool("isAttacking", true);
            ParentAnimator.SetBool("isWalking", false);
        }
    }

    void DealDamageToOther()
    {
        RemainingOtherHp = OtherHealthBar.TakeDamage(AttackPower);
        if (RemainingOtherHp < 1)
        {
            ParentAnimator.SetBool("isAttacking", false);
        }
    }
}
