using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint2 : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints2;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 4f;

    private void Update()
    {
        if (Vector2.Distance(waypoints2[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints2.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints2[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
