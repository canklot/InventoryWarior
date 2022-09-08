using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnTrigger : MonoBehaviour
{
    RoadManager RoadManagerComp;
    void Start()
    {
        RoadManagerComp = GetComponent<RoadManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnTriggerEntered()
    {
        RoadManagerComp.MoveRoad();
    }
}
