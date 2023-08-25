using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_StraightThenStopOn3rdLane1 : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Car;

    // Update is called once per frame
    void Update()
    {
        if (ES.ScooterEnterAccidentCollidor && !ES.ScooterExitZone) NormalDrive();
    }

    void NormalDrive()
    {
        ES.distanceTravelled += Time.deltaTime * 40f;

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
