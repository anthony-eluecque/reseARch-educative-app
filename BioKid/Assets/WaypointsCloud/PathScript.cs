using System.Collections;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public GameObject cloud;
    public GameObject waypointCity;
    public GameObject waypointTarget;

    public int speed;

    private Vector3 originalPosition;
    private Vector3 cityWaypointPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (cloud != null)
        {
            originalPosition = cloud.transform.position;
            StartCoroutine(StoreCityWaypointPosition());
        }
    }

    private IEnumerator StoreCityWaypointPosition()
    {
        yield return new WaitForFixedUpdate(); // Attendre le prochain frame fixe
        cityWaypointPosition = waypointCity.transform.position;
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
            StartCoroutine(ReturnToCityWaypoint());
        }
    }

    private IEnumerator ReturnToCityWaypoint()
    {
        while (cloud.transform.position != cityWaypointPosition)
        {
            cloud.transform.position = Vector3.MoveTowards(cloud.transform.position, cityWaypointPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}