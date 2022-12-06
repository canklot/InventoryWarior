using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    GameObject ParentObject;
    Character CharacterScript;

    Animator ParentAnimator;

    void OnEnable()
    {
        ParentObject = gameObject.transform.parent.gameObject;
        ParentAnimator = ParentObject.GetComponent<Animator>();
        if (ParentObject.tag == "Player")
        {
            CharacterScript = ParentObject.GetComponent<Character>();
        }

        HealthBarClass.DeadAnimationCompleteEnemyEvent += AttackedGameObjeDeatchAnimationComplete;
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        if (OtherCollider.CompareTag("Enemy"))
        {
            CharacterScript.Stop();
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
