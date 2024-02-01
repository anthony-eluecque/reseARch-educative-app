using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    
    public Material dissolveMaterial;




    void Start()
    {


        float floatValue = dissolveMaterial.GetFloat("Dissolve");

        Debug.Log(floatValue);

        // Je veux que progressivement la valeur augmente de 0 à 1

        for (float i = 0; i < 1; i += 0.1f)
        {
            dissolveMaterial.SetFloat("Dissolve", i);
        }
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
