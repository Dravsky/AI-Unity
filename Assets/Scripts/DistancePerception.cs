using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistancePerception : Perception
{
    public override GameObject[] GetGameObjects()
    {
        List<GameObject> result = new List<GameObject>();

        var colliders = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (var collider in colliders)
        {
            if (collider.gameObject == gameObject) continue;
            if (tagName == "" || collider.tag == tagName)
            {
                result.Add(collider.gameObject);
            }
        }

        return result.ToArray();
    }
}
