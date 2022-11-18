using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Vector3[] points;
    private Vector3 currentPos;
    private bool gameStarted;

    public Vector3[] Points => points;
    public Vector3 CurrentPos => currentPos;

    private void Start()
    {
        gameStarted = true;
        currentPos = transform.position;
    }

    public Vector3 GetWaypointPos(int index)
    {
        return CurrentPos + Points[index];
    }

    private void OnDrawGizmos()
    {
        if(!gameStarted && transform.hasChanged)
        {
            currentPos = transform.position;
        }

        for (int i=0; i<points.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(points[i] + currentPos, 0.5f);

            if (i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + currentPos, points[i + 1] + currentPos);
            }
        }
    }
}
