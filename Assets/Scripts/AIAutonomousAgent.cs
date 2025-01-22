using UnityEngine;

public class AIAutonomousAgent : AIAgent
{
    public Perception perception;

    private void Update()
    {
        movement.ApplyForce(Vector3.forward * 10);
        transform.position = Utilities.Wrap(transform.position, new Vector3(-5, -5, -5), new Vector3(5, 5, 5));

        Debug.DrawRay(transform.position, transform.forward * perception.maxDistance, Color.yellow);

        var gameObjects = perception.GetGameObjects();
        foreach (var go in gameObjects)
        {
            Debug.DrawLine(transform.position, go.transform.position, Color.red);
        }
    }
}
