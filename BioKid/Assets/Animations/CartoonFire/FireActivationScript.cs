using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActivationScript : MonoBehaviour
{
    public GameObject fire;

    public List<GameObject> targets;
    private List<ParticleSystem> fires;

    public int speed;

    public float propagationDelay;

    // fire eteint au départ
    private void Start()
    {
        // On initialise la liste des feux
        fires = new List<ParticleSystem>();

        // Pour chaque target, on lui assigne un feu a ses coordonnées

        var i = 0;

        foreach (GameObject target in targets)
        {
            if (i<8)
            {
                ParticleSystem newFire = Instantiate(fire, target.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
                newFire.transform.parent = target.transform;
                newFire.Stop();
                // on stocke le feu dans une liste 
                fires.Add(newFire);
                i++;
            }
        }
    }
    private void PropagateFire()
    {
        foreach (ParticleSystem fire in fires)
        {
            if (!fire.isPlaying)
            {
                fire.Play();
                break;
            }
        }
    }

    // trigger pour activer le feu
    private void OnTriggerEnter(Collider other)
    {
        InvokeRepeating("PropagateFire", 0f, propagationDelay);
    }

    // trigger pour éteindre le feu
    private void OnTriggerExit(Collider other)
    {
        CancelInvoke("PropagateFire");

        // Éteignez tous les feux
        foreach (ParticleSystem fire in fires)
        {
            fire.Stop();
        }
    }
}
