using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackQuestManager : MonoBehaviour
{
    public int confirmValue;
    public int queue;
    public NPCMovement npcMovement, npcMovement1, npcMovement2, npcMovement3, npcMovement4;


    public void Approve()
    {
        confirmValue = 1;
        Time.timeScale = 1f;
        if (queue == 0)
        {
            queue++;
            npcMovement.confirmQuest();
        }
        else if (queue == 1)
        {
            queue++;
            npcMovement1.confirmQuest();
        }
        else if (queue == 2)
        {
            queue++;
            npcMovement2.confirmQuest();
        }
        else if (queue == 3)
        {
            queue++;
            npcMovement3.confirmQuest();
        }
        else if (queue == 4)
        {
            queue++;
            npcMovement4.confirmQuest();
        }
        else
        {

        }
    }

    public void Reject()
    {
        confirmValue = 2;
        Time.timeScale = 1f;
        if (queue == 0)
        {
            queue++;
            npcMovement.confirmQuest();
        }
        else if (queue == 1)
        {
            queue++;
            npcMovement1.confirmQuest();
        }
        else if (queue == 2)
        {
            queue++;
            npcMovement2.confirmQuest();
        }
        else if (queue == 3)
        {
            queue++;
            npcMovement3.confirmQuest();
        }
        else if (queue == 4)
        {
            queue++;
            npcMovement4.confirmQuest();
        }
        else
        {

        }
    }
    public void ResetValue()
    {
        confirmValue = 0;
    }
}
