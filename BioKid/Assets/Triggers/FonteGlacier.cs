using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonteGlacier : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject polarObject;
    public GameObject surfacePolarObject;

    private Vector3 originalPositionGlacier;
    private Vector3 originalPositionPolarBear;
    private void OnTriggerEnter(Collider other)
    {
        if (cubeObject != null)
        {
            originalPositionGlacier = cubeObject.transform.position;
        }
        if (polarObject != null)
        {
            originalPositionPolarBear = polarObject.transform.position;
        }

        StartCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StartCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));

    }

    private void OnTriggerStay(Collider other)
    {
        if (cubeObject != null)
        {
            cubeObject.transform.Translate(Vector3.back * Time.deltaTime);

        }
        if (polarObject != null)
        {
            polarObject.transform.Translate(Vector3.back * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (cubeObject != null)
        {
            cubeObject.transform.position = originalPositionGlacier;
        }

        if (polarObject != null)
        {
            polarObject.transform.position = originalPositionPolarBear;
        }

        StopCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StopCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));

    }

    private IEnumerator UpdateOriginPosition(GameObject target, Vector3 vector)
    {
        while (true)
        {
            vector = target.transform.position;
            yield return null;
        }
    }
}
