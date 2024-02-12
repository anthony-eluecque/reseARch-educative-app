using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    
    public Material dissolveMaterial;




    void Start()
    {

        dissolveMaterial = GetComponent<Renderer>().material;
        dissolveMaterial.SetFloat("_dissolve", 0);
        
        StartCoroutine(Dissolve());

        

    }

    IEnumerator Dissolve()
    {
        float dissolve = 0;
        while (dissolve < 1)
        {
            dissolve += Time.deltaTime;
            dissolveMaterial.SetFloat("_dissolve", dissolve);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
