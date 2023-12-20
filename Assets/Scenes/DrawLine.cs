using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    [SerializeField] Line linePrefab;
    [SerializeField] Gradient lineColor;
    Line currentLine;
    [SerializeField]
    private float minDistance = 0.1f;
    bool isBegan;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentLine != null)
                return;
            BeginDraw();
        }
        if (Input.GetMouseButton(0))
        {
            Draw();

        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDraw();

        }
    }
    void BeginDraw()
    {

        currentLine = Instantiate(linePrefab, transform);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(minDistance);
        isBegan = true;
    }

    void Draw()
    {
        if (!isBegan)
            return;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (currentLine.points.Count >= 2)
        {
            Vector2 current = currentLine.points[currentLine.points.Count - 1];
            float distance = Vector2.Distance(mousePosition, current);
            currentLine.AddPoint(mousePosition);
        }
        if (currentLine != null)
        {
            currentLine.AddPoint(mousePosition);
        }
    }
    void EndDraw()
    {
        if (!isBegan)
            return;
        if (currentLine == null)
            return;
        Destroy(currentLine.gameObject);
        currentLine = null;
        isBegan = false;
    }


}
