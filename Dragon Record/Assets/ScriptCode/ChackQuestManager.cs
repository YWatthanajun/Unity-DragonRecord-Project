using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChackQuestManager : MonoBehaviour
{
    public int confirmValue;
    public NPCMovement npcMovement;

    public void Approve()
    {
        confirmValue = 1;
        npcMovement.confirmQuest();
    }

    public void Reject()
    {
        confirmValue = 2;
        npcMovement.confirmQuest();
    }
}
