using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Obstacle
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        var particles = Resources.Load("Particles/BoomParticles") as GameObject;
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
