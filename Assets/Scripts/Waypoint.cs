using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Waypoint[] waypoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<NavAgent>(out NavAgent agent))
        {
            agent.waypoint = waypoints[Random.Range(0, waypoints.Length)];
        }
    }
}
