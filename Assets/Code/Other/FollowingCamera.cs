using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;

    void FixedUpdate()
    {
        var targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
}
