using PathCreation;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AccidentTriggerZoneForCar : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public GameObject Obstacle;
    public PathCreator pathCreator;
    float StoppingTimer;

    void Update()
    {
        switch (ES.AccidentScenarioNumber)
        {
            case 0:
                if (ES.ScooterEnterAccidentCollidor && !ES.ScooterExitZone) NormalDrive();
                break;
            case 1:
                if (ES.ScooterEnterAccidentCollidor) NormalDrive();
                break;
            case 2:
                if (ES.ScooterExitZone) NormalDrive();
                break;
            case 3:
                if (ES.ScooterEnterAccidentCollidor) NormalDrive();
                break;
            case 4:
                if (ES.ScooterEnterAccidentCollidor) NormalDrive();
                break;
            case 5:
                if (ES.ScooterEnterAccidentCollidor && !ES.ScooterExitZone) NormalDrive();
                break;
            case 6:
                if (ES.ScooterExitZone) NormalDrive();
                break;
        }
    }

    void NormalDrive()
    {
        if(ES.AccidentScenarioNumber == 4)
        {
            StoppingTimer += Time.deltaTime;
            if(!(StoppingTimer >= 3 && StoppingTimer <= 6))
                ES.distanceTravelled += Time.deltaTime * 20f;
        }
        else
            ES.distanceTravelled += Time.deltaTime * 20f;

        Obstacle.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Obstacle.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
