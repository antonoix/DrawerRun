using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Obstacle
{
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward);
    }
}
