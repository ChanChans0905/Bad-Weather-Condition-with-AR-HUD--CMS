using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentGroup : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;

    List<Transform> AccidentList;

    public GameObject Obstacle;
    GameObject Accident;
    float SetNextAccidentTimer;
    float StoppingTimer;
    PathCreator PathCreator;

    void Update()
    {
        if (ES.ChildCountBool)
            AccidentList = GetChildren(transform);

        if (ES.RouteChoice)
        {
            if(ES.ChangeAccident == false)
            {
                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                Accident.SetActive(true);
                //PathCreator = Accident.GetComponent<PathCreator>();
                ES.ChangeAccident = true;
            }

        }

        if (ES.SetNextAccident)
        {
            SetNextAccidentTimer += Time.deltaTime;
            if (SetNextAccidentTimer > 7)
            {
                Accident.SetActive(false);
                ES.AccidentCar.SetActive(false);

                transform.position = GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount).ToString()).transform.position;
                transform.LookAt(GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1).ToString()).transform.position);
                GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1)).SetActive(false);

                ES.ScooterExitZone = false;
                ES.ScooterEnterAccidentCollidor = false;

                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                if (Accident.name == "AccidentStraight_StraightThenStopOn3rdLane") ES.AccidentScenarioNumber = 0;
                else if (Accident.name == "AccidentStraight_TurnRight") ES.AccidentScenarioNumber = 1;
                else if (Accident.name == "AccidentStraight_SuddenStartFrom3rdLane") ES.AccidentScenarioNumber = 2;
                else if (Accident.name == "AccidentTurnRight_ComeFrom2ndLandThenTurnRight") ES.AccidentScenarioNumber = 3;
                else if (Accident.name == "AccidentTurnRight_TurnRightThenStop") ES.AccidentScenarioNumber = 4;
                else if (Accident.name == "AccidentTurnRight_StraightThenStopOn3rdLane") ES.AccidentScenarioNumber = 5;
                else if (Accident.name == "AccidentTurnRight_SuddenStartFrom3rdLane") ES.AccidentScenarioNumber = 6;

                Accident.SetActive(true);
                //PathCreator = Accident.GetComponent<PathCreator>();
                //Debug.Log(Accident);
                SetNextAccidentTimer = 0;
                ES.SetNextAccident = false;
            }
        }

        //switch (ES.AccidentScenarioNumber)
        //{
        //    case 0:
        //        if (ES.ScooterEnterAccidentCollidor && !ES.ScooterExitZone) NormalDrive();
        //        break;
        //    case 1:
        //        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
        //        break;
        //    case 2:
        //        if (ES.ScooterExitZone) NormalDrive();
        //        break;
        //    case 3:
        //        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
        //        break;
        //    case 4:
        //        if (ES.ScooterEnterAccidentCollidor) NormalDrive();
        //        break;
        //    case 5:
        //        if (ES.ScooterEnterAccidentCollidor && !ES.ScooterExitZone) NormalDrive();
        //        break;
        //    case 6:
        //        if (ES.ScooterExitZone) NormalDrive();
        //        break;
        //}

        if (ES.RespawnTrigger)
        {
            SetNextAccidentTimer = 0;
            Accident.SetActive(false);
        }
    }

    void NormalDrive()
    {
        if (ES.AccidentScenarioNumber == 4)
        {
            StoppingTimer += Time.deltaTime;
            if (!(StoppingTimer >= 3 && StoppingTimer <= 6))
                ES.distanceTravelled += Time.deltaTime * 20f;
        }
        else
            ES.distanceTravelled += Time.deltaTime * 20f;

        Debug.Log("WayPointWorking");
        Obstacle.transform.position = PathCreator.path.GetPointAtDistance(ES.distanceTravelled);
        Obstacle.transform.rotation = PathCreator.path.GetRotationAtDistance(ES.distanceTravelled);
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
