using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_Human : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Human;

    void Update()
    {
        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
    }

    void NormalDrive()
    {
        ES.distanceTravelled += Time.deltaTime * 10f;

        Human.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Human.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
