using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected float maxSpeed = 5;
    [SerializeField] protected float minSpeed = 5;
    [SerializeField] protected float maxForce = 5;

    public Vector3 Velocity { get; set; }
    public Vector3 Acceleration { get; set; }
    public Vector3 Direction { get { return Velocity.normalized; } }

    public abstract void ApplyForce(Vector3 force);
}
