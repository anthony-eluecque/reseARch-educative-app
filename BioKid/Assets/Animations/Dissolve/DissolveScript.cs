using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    
    public Material dissolveMaterial;
    public float activationDelay;
    public List<GameObject> targets;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        StartCoroutine(ActivateDissolve());
        
    }

    IEnumerator ActivateDissolve()
    {
        Debug.Log("Coroutine started");
        // on attend activationDelay secondes
        yield return new WaitForSeconds(activationDelay);

        float dissolve = 0;
        while (dissolve < 1)
        {
            dissolve += Time.deltaTime;
            dissolveMaterial.SetFloat("_dissolve", dissolve);
            yield return null;
        }
        yield return null;
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(DesactivateDissolve());
    }

    IEnumerator DesactivateDissolve()
    {
        float dissolve = 1;
        while (dissolve > 0)
        {
            dissolve -= Time.deltaTime;
            dissolveMaterial.SetFloat("_dissolve", dissolve);
            yield return null;
        }
    }
}
