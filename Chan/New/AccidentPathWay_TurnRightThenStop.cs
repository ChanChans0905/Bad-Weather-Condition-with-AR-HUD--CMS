using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_TurnRightThenStop : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    float StoppingTimer;
    public GameObject Car;

    // Update is called once per frame
    void Update()
    {
        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
    }

    void NormalDrive()
    {
        StoppingTimer += Time.deltaTime;
        if (StoppingTimer < 2)
            ES.distanceTravelled += Time.deltaTime * 25f;
        if (!(StoppingTimer >= 5 && StoppingTimer <= 9))
            ES.distanceTravelled += Time.deltaTime * 10f;
        if (StoppingTimer > 10)
            ES.distanceTravelled += Time.deltaTime * 20f;

        Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }
}
