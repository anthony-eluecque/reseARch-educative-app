using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public GameObject cloud;
    public GameObject waypointCity;
    public GameObject waypointTarget;

    public int speed;

    private Vector3 originalPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (cloud != null)
        {
            originalPosition = cloud.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cloud != null)
        {
            // Movetoward avec speed
            cloud.transform.position = Vector3.MoveTowards(cloud.transform.position, waypointTarget.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (cloud != null)
        {
            cloud.transform.position = originalPosition;
        }
    }
}
