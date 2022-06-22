using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1f;


    // Update is called once per frame
    void Update()
    {
        var current = transform.position;
        var target = waypoints[currentWaypointIndex].transform.position;

        if (Vector3.Distance(current, target) < 0.1f) {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(current, target, speed * Time.deltaTime);
    }
}
