using UnityEngine;

public class Particle2D : MonoBehaviour
{
    public Vector2 velocity;
    public float damping;
    public float inverseMass;
    public Vector2 acceleration = Vector2.zero;
    public Vector2 accumulatedForces = Vector2.zero;

    private void FixedUpdate()
    {
        Integrator.Integrate(gameObject.GetComponent<Particle2D>(), Time.deltaTime);
    }
}
