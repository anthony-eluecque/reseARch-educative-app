using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonteGlacier : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject polarObject;
    public GameObject surfacePolarObject;
    public GameObject penguinObject;
    public GameObject iglooObject;


    private Vector3 originalPositionGlacier;
    private Vector3 originalPositionPolarBear;
    private Vector3 originalPositionPinguin;
    private Vector3 originalPositionIgloo;


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
        if (iglooObject != null)
        {
            originalPositionIgloo = iglooObject.transform.position;
        }
        if (penguinObject != null)
        {
            originalPositionPinguin = penguinObject.transform.position;
        }


        StartCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StartCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));

        StartCoroutine(UpdateOriginPosition(penguinObject, originalPositionPinguin));
        StartCoroutine(UpdateOriginPosition(iglooObject, originalPositionIgloo));


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

        if (penguinObject != null)
        {
            penguinObject.transform.Translate(Vector3.down * Time.deltaTime);


        }

        if (iglooObject != null)
        {
            iglooObject.transform.Translate(Vector3.down * Time.deltaTime);


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

        if (penguinObject != null)
        {
            penguinObject.transform.position = originalPositionPinguin;
        }

        if (iglooObject != null)
        {
            iglooObject.transform.position = originalPositionIgloo;
        }

        StopCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StopCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));
        StopCoroutine(UpdateOriginPosition(penguinObject, originalPositionPinguin));
        StopCoroutine(UpdateOriginPosition(iglooObject, originalPositionIgloo));

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
