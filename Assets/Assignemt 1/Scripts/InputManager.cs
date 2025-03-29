using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public List<GameObject> Points;
    private LineRenderer lineRenderer;

    void Start()
    {
        Points = new List<GameObject>();

        // Set up the LineRenderer
        GameObject lineObject = new GameObject("LineRenderer");
        lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos = Input.mousePosition;
            screenPos.z = Camera.main.nearClipPlane; // Set a valid depth
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0; // Ensure 2D positioning

            // Create a point and store it
            GameObject point = CreatePoint(worldPos);
            Points.Add(point);

            // Draw lines
            UpdateLines();
        }
    }

    GameObject CreatePoint(Vector3 position)
    {
        GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point.transform.position = position;
        point.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        return point;
    }

    void UpdateLines()
    {
        if (Points.Count < 2) return;

        lineRenderer.positionCount = Points.Count;
        for (int i = 0; i < Points.Count; i++)
        {
            lineRenderer.SetPosition(i, Points[i].transform.position);
        }

        if (Points.Count >= 3)
        {
            CalculateAngle();
        }
    }

    void CalculateAngle()
    {
        int last = Points.Count - 1;
        Vector2 vecA = (Vector2)(Points[last - 1].transform.position - Points[last - 2].transform.position);
        Vector2 vecB = (Vector2)(Points[last].transform.position - Points[last - 1].transform.position);
        float angle = Vector2.Angle(vecA, vecB);

        Debug.Log("Angle between last two segments: " + angle);
    }
}
