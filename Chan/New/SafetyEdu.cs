using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject Scooter;
    public bool Truck, Human, LaneChanging, Hit;
    float DistanceTravelled;
    float Timer;


    // Update is called once per frame
    void Update()
    {
        Debug.Log(Timer);

        if (Timer < 23)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;
        }


        if (Timer >= 23 && Timer < 28) // Car on 3rd Lane
        {
            Timer += Time.deltaTime * 0.3f;
            DistanceTravelled += Time.deltaTime * 0.3f;
        }


        if (Timer >= 28 && Timer < 49) // Truck
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if(Timer > 40)
                Truck = true;
        }


        if (Timer >= 49 && Timer < 55) // Stop on Red
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;
        }


        if (Timer >= 55 && Timer < 63)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 60)
                Human = true;
        }

        if(Timer >= 63 && Timer < 68) // Human
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;
        }

        if(Timer >= 68 && Timer < 83)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 80)
                LaneChanging = true;
        }

        if(Timer >= 83 && Timer < 88) // Lane Changing
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;
        }

        if(Timer >= 88 && Timer < 127)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 118)
                Hit = true;
        }

        if(Timer >= 127) // Hit
        {
            DistanceTravelled += Time.deltaTime * 0f;
        }

        Scooter.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 11f);
        Scooter.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 11f);
    }
}
