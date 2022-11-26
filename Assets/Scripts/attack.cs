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

    [SerializeField]
    private int AttackPower;

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
            Debug.Log("same");
            return;
        }
        if (OtherCollider.CompareTag("Enemy") | OtherCollider.CompareTag("Player"))
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
