using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinanimator : MonoBehaviour
{
    public Animator animator;
    public string transitionParameter = "TriggerTransition";
    void Start()
    {
        animator.Play(transitionParameter);

        animator.SetBool(transitionParameter, true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

