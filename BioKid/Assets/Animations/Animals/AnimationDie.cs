using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDie : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);

        GetComponent<Animator>().Play("AnimalDie");
    }

}