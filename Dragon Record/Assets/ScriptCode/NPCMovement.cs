using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform questBoard;
    public Transform guildCounter;
    public float moveSpeed = 2f;
    public Adventurer adventurer;

    public void StartDay()
    {
        // Start the NPC's movement
        StartCoroutine(MoveToQuestBoard());
    }

    IEnumerator MoveToQuestBoard()
    {
        while (adventurer.currentQuest == null)
        {
            // Move to the quest board to pick up a quest
            transform.position = Vector2.MoveTowards(transform.position, questBoard.position, moveSpeed * Time.deltaTime);

            if (transform.position == questBoard.position)
            {
                // Pick up a random quest from the quest board
                Item quest = InventoryManager.Instance.Items[Random.Range(0, InventoryManager.Instance.Items.Count)];

                // Assign the quest to the Adventurer's currentQuest variable
                adventurer.currentQuest = quest;

                // Display a message that the NPC has picked up a quest
                Debug.Log(gameObject.name + " has picked up the quest: " + quest.QuestName);

                // Wait for 3 seconds
                yield return new WaitForSeconds(3.0f);
            }

            yield return null;
        }

        // Move to the guild counter to have the player check the quest level
        StartCoroutine(MoveToGuildCounter());
    }

    IEnumerator MoveToGuildCounter()
    {
        while (transform.position != guildCounter.position)
        {
            // Move to the guild counter
            transform.position = Vector2.MoveTowards(transform.position, guildCounter.position, moveSpeed * Time.deltaTime);

            yield return null;
        }

        // Display a message that the NPC has reached the guild counter
        Debug.Log(gameObject.name + " has reached the guild counter with the quest: " + adventurer.currentQuest.QuestName);

        // Notify the player that the NPC has brought a quest to the guild counter
        // and allow the player to check if the quest is suitable for the NPC's level
        // ...

        // Clear the current quest
        adventurer.currentQuest = null;
    }
}