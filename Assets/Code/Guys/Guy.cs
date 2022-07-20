using System;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour, IDying
{
    public event Action<Guy> OnDied;
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Die()
    {
        OnDied?.Invoke(this);
        var particles = Resources.Load("Particles/DieParticles") as GameObject;
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Run()
    {
        _animator.SetTrigger("Run");
    }

    public void Win()
    {
        _animator.SetTrigger("Win");
    }
}
