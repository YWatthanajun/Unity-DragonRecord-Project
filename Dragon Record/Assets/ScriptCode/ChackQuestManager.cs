using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackQuestManager : MonoBehaviour
{
    public int confirmValue;
    public int queue;
    public NPCMovement npcMovement;


    public void Approve()
    {
        confirmValue = 1;
        Time.timeScale = 1f;
        npcMovement.confirmQuest();
    }

    public void Reject()
    {
        confirmValue = 2;
        Time.timeScale = 1f;
        npcMovement.confirmQuest();
    }
    public void ResetValue()
    {
        confirmValue = 0;
    }
}
