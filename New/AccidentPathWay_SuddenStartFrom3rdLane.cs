using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_SuddenStartFrom3rdLane : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Car;

    void Update()
    {
        NormalDrive();
    }

    void NormalDrive()
    {
        if (ES.ScooterExitZone)
        {
            ES.distanceTravelled += Time.deltaTime * 40f;
            Debug.Log(123);
        }
        else
            ES.distanceTravelled = 0;
        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}