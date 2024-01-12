using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonteGlacier : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject polarObject;
    private Vector3 originalPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (cubeObject != null)
        {
            originalPosition = cubeObject.transform.position;
        }
        if (polarObject != null)
        {
            originalPosition = polarObject.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cubeObject != null)
        {
            cubeObject.transform.Translate(Vector3.back * Time.deltaTime);
            Destroy(cubeObject, 1);
        }

        if (cubeObject != null)
        {
            polarObject.transform.Translate(Vector3.back * Time.deltaTime);
     
            Destroy(polarObject, 1);

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (cubeObject != null)
        {
            cubeObject.transform.position = originalPosition;
        }

        if (polarObject != null)
        {
            polarObject.transform.position = originalPosition;
        }
    }
}
