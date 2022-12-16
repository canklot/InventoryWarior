using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventReciver : MonoBehaviour
{
    // Add and use this script to object that needs to trigger events.
    // Like animation events

    Animator BlackScreenAnimator;
    public delegate void AnimationComplete();
    public static event AnimationComplete DeadAnimationCompleteEnemyEvent;
    Attack AttackClass;

    void OnEnable()
    {
        AttackClass = gameObject.GetComponentInChildren<Attack>();
        BlackScreenAnimator = GameObject.FindWithTag("BlackScreen").GetComponent<Animator>();
    }

    void DeadAnimCompleteEnemy()
    {
        Destroy(gameObject);
        DeadAnimationCompleteEnemyEvent();
    }

    void DeadAnimCompletePlayer()
    {
        BlackScreenAnimator.SetTrigger("FadeIn");
    }

    void BlackScreenFadeInCompleted()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Attack()
    {
        AttackClass.DealDamageToOther();
    }
}
