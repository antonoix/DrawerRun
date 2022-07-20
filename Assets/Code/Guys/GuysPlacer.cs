using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuysPlacer : MonoBehaviour
{
    [SerializeField] private List<Guy> _guys;
    [SerializeField] private Transform _border;
    [SerializeField] private Transform _guysHolder;
    [SerializeField] private Transform _collectableGuysHolder;

    private bool _run;
    private const float _speed = 5;

    private void Awake()
    {
        foreach (Transform guy in _guysHolder)
        {
            var guyComponent = guy.GetComponent<Guy>();
            _guys.Add(guyComponent);
            guyComponent.OnDied += HandleDeath;
        }
        foreach (Transform guy in _collectableGuysHolder)
        {
            var collectable = guy.GetComponent<CollectableGuy>();
            collectable.OnCollected += CollectGuy;
        }
    }

    private void HandleDeath(Guy guy)
    {
        _guys.Remove(guy);
    }

    private void CollectGuy(Guy guy)
    {
        guy.transform.SetParent(_guysHolder);
        _guys.Add(guy);
        guy.Run();
        guy.OnDied += HandleDeath;
    }

    public void BuildGuys(List<Vector2> points)
    {
        int deltaIndex = points.Count / _guys.Count;
        Debug.Log(deltaIndex);
        Debug.Log(points.Count);
        Debug.Log(_guys.Count);
        int i = 1;
        foreach (var guy in _guys)
        {
            guy.transform.localPosition = new Vector3(points[i].x * _border.localScale.x / 2,
                0, points[i].y * _border.localScale.z / 2);

            i += deltaIndex;
        }
    }

    public void MakeGuysRun()
    {
        _run = true;
        foreach(var guy in _guys)
        {
            guy.Run();
        }
    }

    public void Win()
    {
        _run = false;
        foreach(var guy in _guys)
        {
            guy.Win();
        }
    }

    private void FixedUpdate()
    {
        if (_run)
            _guysHolder.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
