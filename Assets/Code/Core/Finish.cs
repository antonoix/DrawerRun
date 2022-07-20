using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public event Action OnFinished;
    private bool _finished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Guy>(out var guy) && !_finished)
        {
            _finished = true;
            OnFinished?.Invoke();
        }
    }
}
