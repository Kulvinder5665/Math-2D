using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private LineRenderer lineRenderer;
    private BoxCollider2D laserCollider;
    public float maxDistance = 10f;

    void Start()
    {
        // Ensure player references are assigned
        if (player1 == null || player2 == null)
        {
            Debug.LogError("Player1 or Player2 is not assigned in the Inspector!");
            return;
        }

        // Initialize LineRenderer correctly
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null) // Only add if it doesn't exist
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;

        // Initialize BoxCollider2D for detecting enemies
        laserCollider = GetComponent<BoxCollider2D>();
        if (laserCollider == null)
        {
            laserCollider = gameObject.AddComponent<BoxCollider2D>();
        }
        laserCollider.isTrigger = true;
        laserCollider.enabled = false;
    }

    void Update()
    {
        if (player1 == null || player2 == null) return; // Prevent null errors

        float distance = Vector2.Distance(player1.transform.position, player2.transform.position);

        if (distance < maxDistance)
        {
            ActivateLaser();
        }
        else
        {
            lineRenderer.enabled = false;
            laserCollider.enabled = false;
        }
    }

    void ActivateLaser()
    {
        if (player1 == null || player2 == null) return;

        lineRenderer.enabled = true;
        laserCollider.enabled = true;

        lineRenderer.SetPosition(0, player1.transform.position);
        lineRenderer.SetPosition(1, player2.transform.position);

        // Update BoxCollider2D position & size
        Vector2 midPoint = (player1.transform.position + player2.transform.position) / 2;
        laserCollider.transform.position = midPoint;
        laserCollider.size = new Vector2(Vector2.Distance(player1.transform.position, player2.transform.position), 0.1f);
        laserCollider.transform.rotation = Quaternion.Euler(0, 0, GetAngle(player1.transform.position, player2.transform.position));
    }

    float GetAngle(Vector2 from, Vector2 to)
    {
        Vector2 direction = to - from;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Kill enemy
        }
    }
}
