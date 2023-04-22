using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Color = UnityEngine.Color;

public class PostIt : MonoBehaviour
{
    List<LineRenderer> lineRenderers = new List<LineRenderer>(); // List to store LineRenderer components
    List<List<Vector3>> lineSegments = new List<List<Vector3>>(); // List to store line segments
    bool isDrawing = false;
    int numberOfPointsToValid = 500;

    void Start()
    {
        // Create a new LineRenderer component and add it to the list of lineRenderers
        LineRenderer lineRenderer = CreateLineRenderer();
        lineRenderers.Add(lineRenderer);

        // Create a new line segment and add it to the list of lineSegments
        List<Vector3> newSegment = new List<Vector3>();
        lineSegments.Add(newSegment);
    }

    void Update()
    {
        // Check if the Action Button is pressed down
        if (!isDrawing && Mouse.current.leftButton.isPressed)
        {
            isDrawing = true;
            // Create a new LineRenderer component and add it to the list of lineRenderers
            LineRenderer lineRenderer = CreateLineRenderer();
            lineRenderers.Add(lineRenderer);

            // Create a new line segment and add it to the list of lineSegments
            List<Vector3> newSegment = new List<Vector3>();
            lineSegments.Add(newSegment);
        }

        // Check if the Action Button is released
        if (!Mouse.current.leftButton.isPressed)
        {
            isDrawing = false;

            CountNumberOfPoints();
        }

        // Update the line points while the Action Button is held down
        if (isDrawing)
        {
            // Cast a ray from the player's camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "PostIt")
                {
                    Vector3 mousePosition = hit.point;
                    mousePosition.z = transform.position.z+0.01f;
                    lineSegments[lineSegments.Count - 1].Add(mousePosition); // Add the current mouse position as a point in the last line segment
                    UpdateLineRenderer(); // Update the LineRenderers with the line segments
                }
            }
        }
    }

    LineRenderer CreateLineRenderer()
    {
        // Create a new GameObject with LineRenderer component
        GameObject go = new GameObject("LineRenderer");
        LineRenderer lr = go.AddComponent<LineRenderer>();

        // Set LineRenderer properties
        lr.positionCount = 0;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.material = new Material(Shader.Find("Sprites/Default"));
        lr.startColor = Color.green;
        lr.endColor = Color.green;

        return lr;
    }

    void UpdateLineRenderer()
    {
        for (int i = 0; i < lineRenderers.Count; i++)
        {
            LineRenderer lr = lineRenderers[i];
            List<Vector3> segment = lineSegments[i];

            // Update the LineRenderer with the line segment
            lr.positionCount = segment.Count;
            for (int j = 0; j < segment.Count; j++)
            {
                lr.SetPosition(j, segment[j]);
            }
        }
    }

    void CountNumberOfPoints()
    {
        var count = 0;
        foreach(var segment in lineSegments)
        {
            count += segment.Count;
        }
    }
}
