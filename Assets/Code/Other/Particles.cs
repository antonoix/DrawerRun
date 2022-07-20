using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    void Start()
    {
        Destroy(this, _lifeTime);
    }
}
