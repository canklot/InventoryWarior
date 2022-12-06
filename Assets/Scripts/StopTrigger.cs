using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    GameObject ParentObject;
    Character CharacterScript;
    HealthBarClass PlayerHealthBar;
    Animator ParentAnimator;

    void OnEnable()
    {
        ParentObject = gameObject.transform.parent.gameObject;
        ParentAnimator = ParentObject.GetComponent<Animator>();
        if (ParentObject.tag == "Player")
        {
            CharacterScript = ParentObject.GetComponent<Character>();
            PlayerHealthBar = ParentObject.GetComponent<HealthBarClass>();
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
        if (PlayerHealthBar.isDead)
        {
            return;
        }
        ParentAnimator.SetBool("isWalking", true);
        if (ParentObject.tag == "Player")
        {
            CharacterScript.Move();
        }
    }
}
