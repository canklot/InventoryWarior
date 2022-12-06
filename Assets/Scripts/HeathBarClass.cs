using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeathBarClass : MonoBehaviour
{
    public Slider HealthSlider;
    public Gradient HealthGradient;
    public Image fill;
    public int maxHp = 100;
    public int currentHp;
    public bool isDead { get; private set; } = false;
    private Animator _animator;
    public delegate void AnimationComplete();
    public static event AnimationComplete DeadAnimationCompleteEnemyEvent;
    public static event AnimationComplete DeadAnimationCompletePlayerEvent;

    //add event for player dead
    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        SetMaxHealth(maxHp);
        currentHp = maxHp;
    }

    void SetMaxHealth(int maxhp)
    {
        HealthSlider.maxValue = maxhp;
        // Start the game with max hp
        HealthSlider.value = maxhp;
        // Fill the health bar to 100%
        fill.color = HealthGradient.Evaluate(1f);
    }

    void SetHealth(int hp)
    {
        HealthSlider.value = hp;
        // Change the health bar color
        fill.color = HealthGradient.Evaluate(HealthSlider.normalizedValue);
    }

    public int TakeDamage(int damage)
    {
        if (currentHp >= 0)
        {
            currentHp -= damage;
            SetHealth(currentHp);
            CheckDead();
        }
        return currentHp;
    }

    void DeadAnimCompleteEnemy()
    {
        Destroy(gameObject);

        DeadAnimationCompleteEnemyEvent();
    }

    void DeadAnimCompletePlayer()
    { //has no subscribers also delete event
        //DeadAnimationCompletePlayerEvent();
        SceneManager.LoadScene("GameOverScene");
    }

    void CheckDead()
    {
        if (currentHp == 0)
        {
            isDead = true;
            _animator.SetBool("isDead", true);
        }
    }
}
