using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    [SerializeField]
    private GameObject EnemySpawnPointObject;

    public void SpawnEnemy(Transform SpawnTransform)
    {
        Instantiate(EnemyPrefab, SpawnTransform.position, SpawnTransform.rotation);
    }
}
