using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject ParentObject;
    Animator ParentAnimator;
    int RemainingEnemyHp;
    static HeathBarClass OtherHealthBar;

    void OnEnable()
    {
        HeathBarClass.AnimationCompleteEvent += AttackedGameObjeDeatchAnimationComplete;
    }

    void Update() { }

    void OnTriggerStay(Collider OtherCollider)
    {
        if (OtherCollider.CompareTag("Enemy"))
        {
            RemainingEnemyHp = OtherHealthBar.TakeDamage(1);
            if (RemainingEnemyHp < 1)
            {
                ParentAnimator.SetBool("isAttacking", false);
            }
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        //Debug.Log(OtherCollider.name);
        if (OtherCollider.CompareTag("Enemy"))
        {
            OtherHealthBar = OtherCollider.GetComponent<HeathBarClass>();
            ParentObject = gameObject.transform.parent.gameObject;
            ParentAnimator = ParentObject.GetComponent<Animator>();

            ParentAnimator.SetBool("isAttacking", true);
            ParentAnimator.SetBool("isWalking", false);
        }
    }

    void AttackedGameObjeDeatchAnimationComplete()
    {
        ParentAnimator.SetBool("isWalking", true);
    }
}
