using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    GameObject ParentObject;
    Character CharacterScript;

    void OnEnable()
    {
        ParentObject = gameObject.transform.parent.gameObject;
        if (ParentObject.tag == "Player")
        {
            CharacterScript = ParentObject.GetComponent<Character>();
        }
    }

    void OnTriggerEnter(Collider OtherCollider)
    {
        if (OtherCollider.CompareTag("Enemy"))
        {
            CharacterScript.Stop();
        }
    }
}
