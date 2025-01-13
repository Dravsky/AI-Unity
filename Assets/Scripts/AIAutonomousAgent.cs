using UnityEngine;

public class AIAutonomousAgent : AIAgent
{
    public Perception perception;

    private void Update()
    {
        var gameObjects = perception.GetGameObjects();
        foreach (var go in gameObjects)
        {
            Debug.DrawLine(transform.position, go.transform.position, Color.red);
        }
    }
}
