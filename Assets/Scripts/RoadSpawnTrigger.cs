using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnTrigger : MonoBehaviour
{
    private RoadManager RoadManagerObject;

    private EnemyManager EnemyManagerObject;

    void Start()
    {
        RoadManagerObject = GameObject.Find("RoadManager").GetComponent<RoadManager>();
        EnemyManagerObject = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    void Update() { }

    private void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("OnTriggerExit");
        if (otherCollider.CompareTag("Player"))
        {
            Debug.Log("CompareTag(player)");
            RoadManagerObject.MoveRoad();
            EnemyManagerObject.SpawnEnemy();
        }
    }
}
