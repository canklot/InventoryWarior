using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnTrigger : MonoBehaviour
{
    private RoadManager RoadManagerObject;

    private EnemyManager EnemyManagerObject;
    private GameObject TheRoad;
    private GameObject EnemySpawnPoint;

    void Start()
    { // Search all the gameobjects on the scene with the name
        RoadManagerObject = GameObject.Find("RoadManager").GetComponent<RoadManager>();
        EnemyManagerObject = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        // Get parent
        TheRoad = this.transform.parent.gameObject;
        // Get child
        EnemySpawnPoint = TheRoad.gameObject.transform.Find("EnemySpawnPoint").gameObject;
    }

    void Update() { }

    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            RoadManagerObject.MoveRoad();
            Transform SpawnEnemyCoordinate = EnemySpawnPoint.transform;
            EnemyManagerObject.SpawnEnemy(SpawnEnemyCoordinate);
        }
    }
}
