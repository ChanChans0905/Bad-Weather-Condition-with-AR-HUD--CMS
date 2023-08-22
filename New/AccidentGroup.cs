using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccidentGroup : MonoBehaviour
{
    [SerializeField] ElectricScooter ES;

    List<Transform> AccidentList;

    GameObject Accident;
    float SetNextAccidentTimer;

    void Update()
    {
        if (ES.ChildCountBool)
            AccidentList = GetChildren(transform);

        if (ES.RouteChoice)
        {
            if (ES.ChangeAccident == false)
            {
                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                Accident.SetActive(true);
                ES.ChangeAccident = true;
            }

        }

        if (ES.SetNextAccident)
        {
            SetNextAccidentTimer += Time.deltaTime;
            if (SetNextAccidentTimer > 7)
            {
                Accident.SetActive(false);

                transform.position = GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount).ToString()).transform.position;
                transform.LookAt(GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1).ToString()).transform.position);
                GameObject.Find(ES.PathZoneName + "_" + ES.RouteSelection.ToString() + "_" + (ES.PathZoneCount - 1)).SetActive(false);

                ES.ScooterExitZone = false;
                ES.ScooterEnterAccidentCollidor = false;

                if (ES.StraightOrTurnRight)
                    Accident = AccidentList[Random.Range(0, 3)].gameObject;
                else
                    Accident = AccidentList[Random.Range(3, 7)].gameObject;

                Accident.SetActive(true);

                SetNextAccidentTimer = 0;
                ES.SetNextAccident = false;
            }
        }

        if (ES.RespawnTrigger)
        {
            SetNextAccidentTimer = 0;
            Accident.SetActive(false);
        }
    }

    List<Transform> GetChildren(Transform parent)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in parent) { children.Add(child); }
        return children;
    }
}
