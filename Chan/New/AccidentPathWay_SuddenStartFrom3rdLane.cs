using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentPathWay_SuddenStartFrom3rdLane : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;
    public PathCreator pathCreator;
    public GameObject Car;
    public bool Start;
    float Timer;

    //void Update()
    //{
    //    NormalDrive();
    //}

    //void NormalDrive()
    //{
    //    if (ES.ScooterExitZone)
    //        Start = true;

    //    if(Start)
    //        ES.distanceTravelled += Time.deltaTime * 10f;

    //    Car.transform.position = pathCreator.path.GetPointAtDistance(ES.distanceTravelled);
    //    Car.transform.rotation = pathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    //}

    void Update()
    {
        if (Start)
        {
            Timer += Timer.deltaTime;

            Car.transform.position = pathCreator.path.GetPointAtDistance(Timer * 15f);
            Car.transform.rotation = pathCreator.path.GetRotationAtDistance(Timer * 15f);

            if (Timer > 15)
            {
                Timer = 0;
                Start = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ES")
        {
            Start = true;
        }
    }
}
