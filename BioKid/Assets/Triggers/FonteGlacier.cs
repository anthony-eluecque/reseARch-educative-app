using System.Collections;
using UnityEngine;

public class FonteGlacier : MonoBehaviour
{
    public GameObject cubeObject;
    public GameObject polarObject;
    public GameObject surfacePolarObject;
    public GameObject penguinObject;
    public GameObject iglooObject;
    public GameObject oceanObject;

    public float delayFonteGlacier;
    public float delayDisappearance = 1f; 

    private Vector3 originalPositionGlacier;
    private Vector3 originalPositionPolarBear;
    private Vector3 originalPositionPinguin;
    private Vector3 originalPositionIgloo;
    private Vector3 originalPositionOcean;

    private bool isDelayActive = false;
    private bool isDisappearScheduled = false;
    private Coroutine disappearanceCoroutine;

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
        if (oceanObject != null)
        {
            originalPositionOcean = oceanObject.transform.position;
        }

        StartCoroutine(StartDelay());
        disappearanceCoroutine = StartCoroutine(ScheduleDisappearance());
    }

    private IEnumerator StartDelay()
    {
        StartCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StartCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));
        StartCoroutine(UpdateOriginPosition(penguinObject, originalPositionPinguin));
        StartCoroutine(UpdateOriginPosition(iglooObject, originalPositionIgloo));
        StartCoroutine(UpdateOriginPosition(oceanObject, originalPositionOcean));

        yield return null;
    }

    private IEnumerator ScheduleDisappearance()
    {
        yield return new WaitForSeconds(delayDisappearance);
        isDisappearScheduled = true;

        SetObjectActive(cubeObject, false);
        SetObjectActive(polarObject, false);
        SetObjectActive(penguinObject, false);
        SetObjectActive(iglooObject, false);
        SetObjectActive(oceanObject, false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isDelayActive && !isDisappearScheduled)
        {
            if (cubeObject != null)
                cubeObject.transform.Translate(Vector3.back * Time.deltaTime);

            if (polarObject != null)
                polarObject.transform.Translate(Vector3.back * Time.deltaTime);

            if (penguinObject != null)
                penguinObject.transform.Translate(Vector3.down * Time.deltaTime);

            if (iglooObject != null)
                iglooObject.transform.Translate(Vector3.down * Time.deltaTime);

            if (iglooObject != null)
                oceanObject.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (disappearanceCoroutine != null)
        {
            StopCoroutine(disappearanceCoroutine);
        }

        isDisappearScheduled = false;

        SetObjectActive(cubeObject, true);
        SetObjectActive(polarObject, true);
        SetObjectActive(penguinObject, true);
        SetObjectActive(iglooObject, true);
        SetObjectActive(oceanObject, true);

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

        if (oceanObject != null)
        {
            oceanObject.transform.position = originalPositionOcean;
        }


        StopCoroutine(UpdateOriginPosition(surfacePolarObject, originalPositionGlacier));
        StopCoroutine(UpdateOriginPosition(polarObject, originalPositionPolarBear));
        StopCoroutine(UpdateOriginPosition(penguinObject, originalPositionPinguin));
        StopCoroutine(UpdateOriginPosition(iglooObject, originalPositionIgloo));
        StopCoroutine(UpdateOriginPosition(oceanObject, originalPositionOcean));

    }

    private IEnumerator UpdateOriginPosition(GameObject target, Vector3 vector)
    {
        while (true)
        {
            vector = target.transform.position;
            yield return null;
        }
    }

    private void SetObjectActive(GameObject obj, bool isActive)
    {
        if (obj != null)
        {
            obj.SetActive(isActive);
        }
    }
}
