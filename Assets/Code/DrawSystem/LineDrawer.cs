using System;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public event Action<List<Vector2>> OnDrawed;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _brush;
    private const float _canvasWidth = 0.9f;
    private const float _canvasHeight = 0.3f;

    private bool _canDraw;
    public void EnableDrawing(bool canDraw) => _canDraw = canDraw;
    private LineRenderer _lineRenderer;

    private Vector2 _lastPos;

    private void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (_canDraw)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                CreateBrush();
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                PointToMousePos();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                OnDrawed?.Invoke(GetNormalizedPoints());
                Destroy(_lineRenderer);
                _lineRenderer = null;
            }
        }
    }

    private void CreateBrush()
    {
        GameObject brushInstance = Instantiate(_brush);
        _lineRenderer = brushInstance.GetComponent<LineRenderer>();
    }

    private void AddAPoint(Vector2 pointPos)
    {
        _lineRenderer.positionCount++;
        int positionIndex = _lineRenderer.positionCount - 1;
        _lineRenderer.SetPosition(positionIndex, pointPos);
    }

    private void PointToMousePos()
    {
        if (_lineRenderer == null)
            return;
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        if ((_lastPos != mousePos))
        {
            AddAPoint(mousePos);
            _lastPos = mousePos;
        }
    }

    private List<Vector2> GetNormalizedPoints()
    {
        var points = new List<Vector2>();
        Vector3 camera = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        var xMax = camera.x;
        var yMax = camera.y;
        for (int i = 0; i < _lineRenderer.positionCount - 1; i++)
        {
            var newPoint = _lineRenderer.GetPosition(i);
            newPoint.x = newPoint.x / xMax * (1 / _canvasWidth);
            newPoint.y /= yMax;
            newPoint.y = (newPoint.y + 0.7f) * (1 / _canvasHeight);
            points.Add(newPoint);
        }
        return points;
    }
}