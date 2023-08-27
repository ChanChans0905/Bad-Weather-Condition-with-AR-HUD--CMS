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
        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
    }

    void NormalDrive()
    {
        if (!ES.ScooterExitZone)
            ES.distanceTravelled += Time.deltaTime * 30f;

        if (ES.Stop)
            ES.distanceTravelled = 610;

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
