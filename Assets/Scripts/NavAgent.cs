using UnityEngine;

public class NavAgent : AIAgent
{
    public Waypoint waypoint { get; set; }

    private void Start()
    {
        var waypoints = FindObjectsByType<Waypoint>(FindObjectsSortMode.None);
        if (waypoints.Length > 0)
        {
            waypoint = waypoints[Random.Range(0, waypoints.Length)];
        }
    }

    private void Update()
    {
        if (waypoint != null)
        {
            movement.MoveTowards(waypoint.transform.position);
        }

        transform.forward = movement.Direction;
    }
}
