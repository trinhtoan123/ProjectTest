using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer _line;
    public List<Vector2> points = new List<Vector2>();
    public int pointsCount = 0;
    float pointsMinDistance = 0.1f;
    [SerializeField, Range(0.01f, 2)]
    private float width;
  
    public void AddPoint(Vector2 newPoint)
    {
        if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
            return;

        points.Add(newPoint);
        pointsCount++;

        //Line Renderer
        _line.positionCount = pointsCount;
        _line.startWidth = _line.endWidth = width;
        _line.SetPosition(pointsCount - 1, newPoint);

    }
    public Vector2 GetLastPoint()
    {
        return (Vector2)_line.GetPosition(pointsCount - 1);
    }
    public void SetLineColor(Gradient colorGradient)
    {
        _line.colorGradient = colorGradient;
    }
    public void SetPointsMinDistance(float distance)
    {
        pointsMinDistance = distance;
    }

}
