using UnityEngine;

[CreateAssetMenu(fileName = "AutonomousAgentData", menuName = "Data/AutonomousAgentData")]
public class AutonomousAgentData : ScriptableObject
{
    [Range(0, 10)] public float displacement;
    [Range(0, 10)] public float distance;
    [Range(0, 10)] public float radius;

    [Range(0, 5)] public float cohesionWeight;
    [Range(0, 5)] public float separationWeight;
    [Range(0, 5)] public float separationRadius;
    [Range(0, 5)] public float alignmentWeight;
}