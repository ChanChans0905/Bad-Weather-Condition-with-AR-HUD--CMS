using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyEdu_LaneChanging : MonoBehaviour
{
    [SerializeField] SafetyEdu SE;
    public PathCreator pathCreator;
    public GameObject Car;
    float DistanceTravelled;
    float Timer;

    void Update()
    {
        if (SE.LaneChanging)
        {
            Timer += Time.deltaTime;
            DistanceTravelled += Time.deltaTime;

            Car.transform.position = pathCreator.path.GetPointAtDistance(DistanceTravelled * 14f);
            Car.transform.rotation = pathCreator.path.GetRotationAtDistance(DistanceTravelled * 14f);

            if (Timer > 40)
            {
                SE.LaneChanging = false;
                Timer = 0;
                DistanceTravelled = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
