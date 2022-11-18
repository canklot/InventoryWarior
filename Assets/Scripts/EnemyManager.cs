using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public void SpawnEnemy()
    {
        Debug.Log("spawn");
        Instantiate(EnemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
