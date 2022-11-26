using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject ParentObject;
    Animator ParentAnimator;
    int RemainingEnemyHp;
    HeathBarClass OtherHealthBar;

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
        if (OtherCollider.CompareTag("Enemy"))
        {
            RemainingEnemyHp = OtherHealthBar.TakeDamage(AttackPower);
            if (RemainingEnemyHp < 1)
            {
                ParentAnimator.SetBool("isAttacking", false);
            }
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        //Debug.Log(OtherCollider.name)
        if (OtherCollider.gameObject == ParentObject.gameObject)
        {
            // Debug.Log("same");
            return;
        }
        if (OtherCollider.CompareTag("Enemy") | OtherCollider.CompareTag("Player"))
        {
            // Debug.Log(OtherCollider.tag);
            OtherHealthBar = OtherCollider.GetComponent<HeathBarClass>();

            ParentAnimator.SetBool("isAttacking", true);
            ParentAnimator.SetBool("isWalking", false);
        }
    }
}
