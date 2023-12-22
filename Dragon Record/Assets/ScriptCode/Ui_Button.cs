using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Button : MonoBehaviour
{
    public GameObject activeGameObject;
    public bool startDay;

    void Start()
    {
        activeGameObject = GameObject.Find("StartButton");
    }

    public void StartDayButton()
    {
        startDay = true;
        PathFollow pathFollowClass = FindObjectOfType<PathFollow>();
        if (pathFollowClass != null)
        {
            pathFollowClass.StartDay(startDay);
            activeGameObject.SetActive(false);
        }
    }
}