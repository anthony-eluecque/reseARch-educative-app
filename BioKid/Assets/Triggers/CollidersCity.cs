using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersCity : MonoBehaviour
{
    public GameObject cubeObject;
    private Vector3 originalPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (cubeObject != null)
        {
            originalPosition = cubeObject.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cubeObject != null)
        {
            cubeObject.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (cubeObject != null)
        {
            cubeObject.transform.position = originalPosition;
        }
    }
}
