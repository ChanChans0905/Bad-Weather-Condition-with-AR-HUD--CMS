using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ElectricScooter : MonoBehaviour
{
    [SerializeField] FadeInOut FadeInOut;

    public GameObject PathPointer;
    public GameObject AccidentGroup;
    public GameObject FailureNotice;
    public GameObject PathZoneGroup_1, PathZoneGroup_2, PathZoneGroup_3;
    public GameObject PathZone_1_0, PathZone_2_0, PathZone_3_0;

    public int PathZoneCount;
    public int RouteSelection;

    float RouteChoiceTimer, OnTriggerThreshold, RespawnTimer;

    public bool ChildCountBool, TurnOnNextPathZone, LookAtNextPathZone;
    public bool MainTask, RouteChoice, RespawnTrigger, GameSuccessBool;
    public bool StraightOrTurnRight, SetNextAccident, ChangeAccident;
    public bool ScooterExitZone, ScooterEnterZone, ScooterEnterAccidentCollidor;

    public string PathZoneName = "PathZone";
    string AccidentStraight = "AccidentStraight";
    string AccidentTurnRight = "AccidentTurnRight";

    GameObject FindTargetZone;
    Vector3 TargetZone, AccidentGroupStartPosition, ScooterStartPosition;
    Quaternion AccidentGroupStartRotation, ScooterStartRotation;

    string[] Route_StraightOrTurnRight = new string[10];
    int[] AccidentOccur = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
    string[] AccidentScenario_Straight = new string[] { "StraightThenStopOn3rdLane", "TurnRight", "SuddenStartFrom3rdLane" };
    string[] AccidentScenario_TurnRight = new string[] { "TurnRightThenStop", "ComeFrom2ndLandThenTurnRight", "StraightThenStopOn3rdLane", "SuddenStartFrom3rdLane" };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RouteSelection = 1;
            RouteChoice = true;
        }

        if (RouteChoice)
        {
            ChildCountBool = true;
            RouteChoiceTimer += Time.deltaTime;

            if (RouteSelection == 1)
            {
                PathZoneGroup_1.SetActive(true);
                PathZone_1_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "Straight", "Straight", "TurnRight", "Straight", "TurnRight", "Straight", "Straight", "TurnRight", "TurnRight", "TurnRight" };
            }
            else if (RouteSelection == 2)
            {
                PathZoneGroup_2.SetActive(true);
                PathZone_2_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "TurnRight", "Straight", "TurnRight", "TurnRight", "Straight", "TurnRight", "Straight", "Straight", "TurnRight", "TurnRight" };
            }
            else if (RouteSelection == 3)
            {
                PathZoneGroup_3.SetActive(true);
                PathZone_3_0.SetActive(true);
                Route_StraightOrTurnRight = new string[] { "TurnRight", "Straight", "TurnRight", "Straight", "TurnRight", "Straight", "TurnRight", "TurnRight", "Straight", "TurnRight" };
            }

            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;

            AccidentGroupStartPosition = AccidentGroup.transform.position;
            AccidentGroupStartRotation = AccidentGroup.transform.rotation;
            ScooterStartPosition = transform.position;
            ScooterStartRotation = transform.rotation;

            LookAtNextPathZone = true;

            if (RouteChoiceTimer > 3)
            {
                RouteChoice = false;
                MainTask = true;
                ChildCountBool = false;
                RouteChoiceTimer = 0;
                ChangeAccident = false;
            }
        }

        if (MainTask)
        {
            if (OnTriggerThreshold <= 6)
                OnTriggerThreshold += Time.deltaTime;

            Vector3 direction = TargetZone - PathPointer.transform.position;
            direction.y = 2.5f;
            Quaternion toRotation = Quaternion.FromToRotation(PathPointer.transform.forward, direction);
            PathPointer.transform.rotation = Quaternion.Lerp(PathPointer.transform.rotation, toRotation, Time.deltaTime);
        }

        if (LookAtNextPathZone)
        {
            FindTargetZone = GameObject.Find(PathZoneName + "_" + RouteSelection.ToString() + "_" + PathZoneCount.ToString());
            TargetZone = FindTargetZone.transform.position;
        }

        if (SetNextAccident)
        {
            if (Route_StraightOrTurnRight[PathZoneCount] == "Straight")
                StraightOrTurnRight = true;
            else if (Route_StraightOrTurnRight[PathZoneCount] == "TurnRight")
                StraightOrTurnRight = false;
        }

        if (RespawnTrigger) Respawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            RespawnTrigger = true;
            FadeInOut.FadingEvent = true;
            FailureNotice.SetActive(true);
        }

        if (other.gameObject.CompareTag("EndPoint"))
        {
            RespawnTrigger = true;
            FadeInOut.FadingEvent = true;
            GameSuccessBool = true;
        }

        if (other.gameObject.CompareTag("PathZone"))
        {
            if (OnTriggerThreshold >= 2)
            {
                ScooterEnterZone = true;
                PathZoneCount++;
                TurnOnNextPathZone = true;
                OnTriggerThreshold = 0;
            }
        }
        if (other.gameObject.CompareTag("AccidentCollidor"))
            ScooterEnterAccidentCollidor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PathZone"))
        {
            SetNextAccident = true;
            ScooterExitZone = true;
        }
    }

    static public T[] ShuffleArray<T>(T[] array)
    {
        int random1, random2;
        T temp;

        for (int i = 0; i < array.Length; ++i)
        {
            random1 = UnityEngine.Random.Range(0, array.Length);
            random2 = UnityEngine.Random.Range(0, array.Length);

            temp = array[random1];
            array[random1] = array[random2];
            array[random2] = temp;
        }

        return array;
    }

    public void Respawn()
    {
        FadeInOut.Fade();
        RespawnTimer += Time.deltaTime;
        transform.position = ScooterStartPosition;
        transform.rotation = ScooterStartRotation;
        AccidentGroup.transform.position = AccidentGroupStartPosition;
        AccidentGroup.transform.rotation = AccidentGroupStartRotation;

        if (RespawnTimer >= 3)
        {
            RespawnTrigger = false;
            RespawnTimer = 0;
        }
    }
}
