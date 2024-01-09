using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] public float moveSpeed;
    private int pointsIndex;
    private bool moveQuestBoard;
    private bool acceptQuest;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveQuestBoard == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            float distanceToTarget = Vector2.Distance(transform.position, Points[pointsIndex].transform.position);
            if (distanceToTarget <= float.Epsilon)
            {
                //moveQuestBoard = false;
                pointsIndex ++;
                //acceptQuest = true;
            }
        }
        if (acceptQuest == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[4].transform.position, moveSpeed * Time.deltaTime);
            float distanceToTarget = Vector2.Distance(transform.position, Points[pointsIndex].transform.position);
            if (distanceToTarget <= float.Epsilon)
            {
                
            }
        }
    }

    public void StartDay(bool startDay)
    {
        Debug.Log("Start Day received: " + startDay);
        moveQuestBoard = startDay;
    }
}
