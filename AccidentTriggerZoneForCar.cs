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
    bool AccidentStart;

    void Update()
    {
        switch (ES.AccidentScenarioNumber)
        {
            case 0:
                AccidentScenario_0();
                break;
            case 1:
                AccidentScenario_1();
                break;
            case 2:
                AccidentScenario_2();
                break;
            case 3:
                AccidentScenario_3();
                break;
            case 4:
                AccidentScenario_4();
                break;
            case 5:
                AccidentScenario_5();
                break;
            case 6:
                AccidentScenario_6();
                break;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Scooter"))
        {
            AccidentStart = true;
        }
    }

    void NormalDrive()
    {
        ES.distanceTravelled += Time.deltaTime * 20f;
        Obstacle.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Obstacle.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }

    void AccidentScenario_0()
    {
        if (!ES.ScooterExitZone && AccidentStart)
            NormalDrive();

        // else
    }

    void AccidentScenario_1()
    {

    }

    void AccidentScenario_2()
    {

    }

    void AccidentScenario_3()
    {

    }

    void AccidentScenario_4()
    {

    }

    void AccidentScenario_5()
    {

    }    
    void AccidentScenario_6()
    {

    }
}
