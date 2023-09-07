using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject Scooter;
    public GameObject GreenLight, RedLight, DeadSound;
    public GameObject Notice_SlowDown, Notice_Truck, Notice_StopOnRed, Notice_Human, Notice_LaneChanging, Notice_Hit, Notice_KeepLane, Notice_DriveOnRed;
    public bool Truck, Human, LaneChanging, Hit;
    float DistanceTravelled;
    float Timer;


    void Update()
    {
        Debug.Log(Timer);

        if (Timer < 28)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;
        }

        if(Timer > 5 && Timer < 10)
            Notice_KeepLane.SetActive(true);

        if (Timer > 10 && Timer < 11)
            Notice_KeepLane.SetActive(false);

        if (Timer >= 28 && Timer < 31) // Car on 3rd Lane
        {
            Notice_SlowDown.SetActive(true);
            Timer += Time.deltaTime * 0.3f;
            DistanceTravelled += Time.deltaTime * 0.3f;
        }

        if (Timer >= 31 && Timer < 56) // Truck
        {
            Notice_SlowDown.SetActive(false);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 36)
            {
                Truck = true;
                Notice_Truck.SetActive(true);
            }
            
            if(Timer > 41)
                Notice_Truck.SetActive(false);

        }

        if (Timer >= 56 && Timer < 62) // Stop on Red
        {
            Notice_StopOnRed.SetActive(true);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;

            if(Timer > 61)
            {
                RedLight.SetActive(false);
                GreenLight.SetActive(true);
            }
                
        }

        if (Timer >= 62 && Timer < 73)
        {
            Notice_StopOnRed.SetActive(false);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 65)
                Human = true;
        }

        if (Timer >= 70 && Timer < 76) // Human
        {
            Notice_Human.SetActive(true);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;
        }

        if (Timer >= 76 && Timer < 83)
        {
            Notice_Human.SetActive(false);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 80)
                LaneChanging = true;
        }

        if (Timer >= 83 && Timer < 88) // Lane Changing
        {
            Notice_LaneChanging.SetActive(true);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime * 0f;
        }

        if (Timer >= 88 && Timer < 135)
        {
            Notice_LaneChanging.SetActive(false);
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            if (Timer > 129)
            {
                Notice_DriveOnRed.SetActive(true);
                Hit = true;
            }
                
        }

        if (Timer >= 134.5f) // Hit
        {
            Notice_DriveOnRed.SetActive(false);
            Notice_Hit.SetActive(true);
            DistanceTravelled += Time.deltaTime * 0f;
        }
            Scooter.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 11f);
            Scooter.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 11f);
    }
}
