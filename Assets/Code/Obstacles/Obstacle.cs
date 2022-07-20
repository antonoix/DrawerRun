using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDying>(out var collided))
        {
            collided.Die();
        }
    }
}
