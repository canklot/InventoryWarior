using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> roads;
    private float Offset = 50f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveRoad()
    {
        GameObject TheRoad = roads[0];
        roads.Remove(TheRoad);
        float newZ = roads[roads.Count - 1].transform.position.z + Offset;
        TheRoad.transform.position = new Vector3(0, 0, newZ);
        roads.Add(TheRoad);
    }

}
