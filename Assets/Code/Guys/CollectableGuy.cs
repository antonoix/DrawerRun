using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Guy))]
public class CollectableGuy : MonoBehaviour
{
    public event Action<Guy> OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Guy>(out var collided))
        {
            OnCollected?.Invoke(GetComponent<Guy>());
            var particles = Resources.Load("Particles/CollectGuyParticles") as GameObject;
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(GetComponent<Rigidbody>());
            Destroy(this);
        }
    }
}
