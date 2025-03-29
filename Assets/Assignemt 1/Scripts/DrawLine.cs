using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine
{
    public float x;
    public float y;
    public float z;

    public DrawLine(float _x, float _y)
    {
        x = _x;
        y = _y;
        z = 0; // Set Z to 0 for 2D
    }

    public static void DrawLineTwoPoints(DrawLine prevPoint, DrawLine nextPoint, Color color, float width, bool looping)
    {
        GameObject lineObject = new GameObject("Line_" + prevPoint.ToString() + "_" + nextPoint.ToString());
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        // Set material and color
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

        // Set width
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;

        // Use world space
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = looping;

        // Set positions correctly
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(prevPoint.x, prevPoint.y, prevPoint.z));
        lineRenderer.SetPosition(1, new Vector3(nextPoint.x, nextPoint.y, nextPoint.z));
    }
}
