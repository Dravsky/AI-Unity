using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DistancePerception : Perception
{
    public override GameObject[] GetGameObjects()
    {
        List<GameObject> result = new List<GameObject>();

        // Get all colliders inside sphere.
        var colliders = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (var collider in colliders)
        {
            // Do not include ourselves
            if (collider.gameObject == gameObject) continue;
            // Check for matching tag
            if (tagName == "" || collider.tag == tagName)
            {
                // Check if within max angle range
                Vector3 direction = collider.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);
                if (angle <= maxAngle)
                {
                    // Add game oject to result
                    result.Add(collider.gameObject);
                }
            }

        }

        return result.ToArray();
    }
}
