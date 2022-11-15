using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp;
    public HeathBarClass enemyHealthBar;

    void Start()
    {
        currentHp = maxHp;
        enemyHealthBar.SetHealth(maxHp);
    }


    void Update()
    {

    }

    void OnTriggerStay(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            TakeDamage(1);
        }

    }

    void TakeDamage(int damage)
    {
        currentHp -= damage;
        enemyHealthBar.SetHealth(currentHp);
    }

}
