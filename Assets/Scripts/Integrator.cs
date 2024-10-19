using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator
{
    public static void Integrate(Particle2D particle, float dt)
    {
        particle.transform.position = new Vector3(particle.transform.position.x + particle.velocity.x * dt, particle.transform.position.y + particle.velocity.y * dt, 0);
        particle.velocity += particle.acceleration * dt;
        particle.velocity *= Mathf.Pow(particle.damping,dt);
    }
}
