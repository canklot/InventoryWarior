using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnTrigger : MonoBehaviour
{
    RoadManager RoadManagerComponent;
    EnemyManager EnemyManagerComponent;

    void Start()
    {
        RoadManagerComponent = GetComponent<RoadManager>();
        EnemyManagerComponent = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update() { }

    public void SpawnTriggerEntered()
    {
        Debug.Log("SpawnTriggerEntered");
        RoadManagerComponent.MoveRoad();
        EnemyManagerComponent.SpawnEnemy();
    }
}
