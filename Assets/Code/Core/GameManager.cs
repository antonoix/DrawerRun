using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LineDrawer _drawer;
    [SerializeField] private GuysPlacer _guysPlacer;
    [SerializeField] private Finish _finish;

    private bool _started;

    void Awake()
    {
        _drawer.OnDrawed += HandleDraw;
        _finish.OnFinished += HandleFinish;
    }

    private void HandleDraw(List<Vector2> points)
    {
        if (!_started)
            StartGame();
        _guysPlacer.BuildGuys(points);
    }

    private void StartGame()
    {
        _started = true;
        _guysPlacer.MakeGuysRun();
    }

    private void HandleFinish()
    {
        _guysPlacer.Win();
    }
}
