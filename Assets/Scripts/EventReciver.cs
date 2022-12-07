using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventReciver : MonoBehaviour
{
    public delegate void AnimationComplete();
    public static event AnimationComplete DeadAnimationCompleteEnemyEvent;
    Attack _Attack;

    void OnEnable()
    {
        _Attack = gameObject.GetComponentInChildren<Attack>();
    }

    void DeadAnimCompleteEnemy()
    {
        Destroy(gameObject);
        DeadAnimationCompleteEnemyEvent();
    }

    void DeadAnimCompletePlayer()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Attack()
    {
        Debug.Log("event reciver Attack");
        _Attack.DealDamageToOther();
    }
}
