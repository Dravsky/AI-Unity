using System;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
    [SerializeField] int numRaycast = 2;

    public override GameObject[] GetGameObjects()
    {
        // create result list
        List<GameObject> result = new List<GameObject>();

        // get array of directions using Utilities.GetDirectionsInCircle
        Vector3[] directions = Utilities.GetDirectionsInCircle(numRaycast, maxAngle);
        // iterate through directions
        foreach (Vector3 direction in directions)
	    {
            // create ray from transform postion in the direction of (transform.rotation * direction)
            Ray ray = new Ray(transform.position, transform.rotation * direction);
            // raycast ray
            if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask))
            {
                // check if collision is self, skip if so
                if (raycastHit.collider.gameObject == gameObject) continue;
                // check tag, skip if tagName != "" and !CompareTag
                if (tagName != "" && !raycastHit.collider.CompareTag(tagName)) continue;

                // add game object to results
                result.Add(raycastHit.collider.gameObject);
            }
        }

        // convert list to array
        return result.ToArray();
    }

    public override bool GetOpenDirection(ref Vector3 openDirection)
    {
        // get array of directions using Utilities.GetDirectionsInCircle
        Vector3[] directions = Utilities.GetDirectionsInCircle(numRaycast, maxAngle);
        // iterate through directions
        foreach (Vector3 direction in directions)
        {
            // cast ray from transform position in the direction of (transform.rotation * direction)
            Ray ray = new Ray(transform.position, transform.rotation * direction);
            // if there is NO raycast hit then that is an open direction
            if (!Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance, layerMask))
            {
                // set open direction
                openDirection = ray.direction;
                return true;
            }
        }

        // no open direction
        return false;
    }
}
