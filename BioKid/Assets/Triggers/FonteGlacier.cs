using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonteGlacier : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject polarObject;
    public GameObject penguinObject;
    public GameObject iglooObject;

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

        if (penguinObject != null)
        {
            originalPosition = penguinObject.transform.position;
        }
        if (iglooObject != null)
        {
            originalPosition = iglooObject.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cubeObject != null)
        {
            cubeObject.transform.Translate(Vector3.back * Time.deltaTime);
            Destroy(cubeObject, 1);
        }

        if (polarObject != null)
        {
            polarObject.transform.Translate(Vector3.back * Time.deltaTime);
     
            Destroy(polarObject, 1);

        }

        if (penguinObject != null)
        {
            penguinObject.transform.Translate(Vector3.down * Time.deltaTime);

            Destroy(penguinObject, 1);

        }

        if (iglooObject != null)
        {
            iglooObject.transform.Translate(Vector3.down * Time.deltaTime);

            Destroy(iglooObject, 1);

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

        if (penguinObject != null)
        {
            penguinObject.transform.position = originalPosition;
        }

        if (iglooObject != null)
        {
            iglooObject.transform.position = originalPosition;
        }
    }
}
