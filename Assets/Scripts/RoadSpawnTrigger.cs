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
    {
        RoadManagerObject = GameObject.Find("RoadManager").GetComponent<RoadManager>();
        EnemyManagerObject = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        TheRoad = this.transform.parent.gameObject;
        EnemySpawnPoint = TheRoad.gameObject.transform.GetChild(1).gameObject;
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
