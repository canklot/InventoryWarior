using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject ParentObject;
    Animator ParentAnimator;
    int RemainingEnemyHp;
    HeathBarClass OtherHealthBar;
    Character CharacterScript;

    void OnEnable()
    {
        HeathBarClass.AnimationCompleteEvent += AttackedGameObjeDeatchAnimationComplete;
        ParentObject = gameObject.transform.parent.gameObject;
        ParentAnimator = ParentObject.GetComponent<Animator>();
        if (ParentObject.tag == "Player")
        {
            CharacterScript = ParentObject.GetComponent<Character>();
        }
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
            Debug.Log(OtherCollider.tag);
            OtherHealthBar = OtherCollider.GetComponent<HeathBarClass>();

            ParentAnimator.SetBool("isAttacking", true);
            ParentAnimator.SetBool("isWalking", false);

            if (ParentObject.tag == "Player")
            {
                Debug.Log("Stop");
                CharacterScript.Stop();
            }
        }
    }

    void AttackedGameObjeDeatchAnimationComplete()
    {
        ParentAnimator.SetBool("isWalking", true);
        if (ParentObject.tag == "Player")
        {
            CharacterScript.Move();
        }
    }
}
