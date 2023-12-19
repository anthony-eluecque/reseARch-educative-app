using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Smoke_Physic : MonoBehaviour { 

    [SerializeField] ParticleSystem ps = null;
    ParticleSystem.MainModule main = new ParticleSystem.MainModule();

    [Header("PS Properties")]
    [SerializeField] private float sizeAcceleration = 150f;
    [SerializeField] private float lifeAcceleration = 150f;

    [SerializeField] private float sizeVelocity = 15f;
    [SerializeField] private float lifeVelocity = 15f;


    [Header("Smoke Physic")]
    [SerializeField] private float maxSpeed = -1f;
    [SerializeField] private float maxAcceleration = -1f;

    private float velocityFinal = -1f;
    private float velocityInit = -1f;

    private Vector3 pos = new Vector3();
    private Vector3 posLast = new Vector3();

    void Start()
    {
        main = ps.main;
        
    }

    void Update()
    {

        posLast = pos;
        pos = transform.position;

        velocityInit = velocityFinal;
        velocityFinal = (pos - posLast).magnitude / Time.deltaTime;

        float velocityPercent = velocityFinal / maxSpeed;
        float acceleration = (velocityFinal - velocityInit) / Time.deltaTime;
        float absAccPercent = Mathf.Abs(acceleration / maxAcceleration);

        Debug.Log($"Velocity: {velocityFinal} : Velocity Percent: {velocityPercent}. Acceleration : {acceleration}");

        ShowVehicleEffort(velocityPercent, absAccPercent);
        
    }

    private void ShowVehicleEffort(float vMod, float aMod)
    {
        if (aMod > .2f)
        {
            main.startSize = sizeAcceleration * aMod;
            main.startLifetime = lifeAcceleration * aMod;
        }
        else
        {
            main.startSize = sizeVelocity * vMod;
            main.startLifetime = lifeVelocity * vMod;
        }
    }
}
