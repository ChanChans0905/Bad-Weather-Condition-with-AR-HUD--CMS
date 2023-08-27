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
            ES.distanceTravelled += Time.deltaTime * 10f;
        }
        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
