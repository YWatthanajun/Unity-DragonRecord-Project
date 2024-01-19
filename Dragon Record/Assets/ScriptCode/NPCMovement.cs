using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class NPCMovement : MonoBehaviour
{
    public Transform questBoard;
    public Transform guildCounter;
    public Transform exitArea;
    public float moveSpeed = 2f;
    public Adventurer adventurer;
    public GameObject checkQuest;
    public int confirm;
    public ChackQuestManager chackQuestManager;
    public GameObject UIcheck;
    public Animator anim;
    //public AdventurerInfo adventurerInfo;

    public void StartDay()
    {
        // Start the NPC's movement
        StartCoroutine(MoveToQuestBoard());
    }

    IEnumerator MoveToQuestBoard()
    {
        if (anim == null)
        {
            Debug.LogError("Animator is not assigned to NPCMovement script.");
            yield break;
        }

        Debug.Log("Triggering PickUp_NPC_01 animation.");
        anim.SetTrigger("PickUp_NPC_01");

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
                InventoryManager.Instance.Remove(quest);

                // Display a message that the NPC has picked up a quest
                Debug.Log(gameObject.name + " has picked up the quest: " + quest.QuestName);

                // Wait for 3 seconds
                //anim.SetTrigger("PickUpQuest");
                yield return new WaitForSeconds(3.0f);
            }

            yield return null;
        }

        // Move to the guild counter to have the player check the quest level
        StartCoroutine(MoveToGuildCounter());
    }

    IEnumerator MoveToGuildCounter()
    {
        //adventurerInfo.questText.text("");
        while (transform.position != guildCounter.position)
        {
            // Move to the guild counter
            transform.position = Vector2.MoveTowards(transform.position, guildCounter.position, moveSpeed * Time.deltaTime);

            yield return null;
        }

        // Display a message that the NPC has reached the guild counter
        Debug.Log(gameObject.name + " has reached the guild counter with the quest: " + adventurer.currentQuest.QuestName);
        chack();

        // Move to the exit area
    }

    IEnumerator MoveToExitArea()
    {
        yield return new WaitForSeconds(1.0f);
        while (transform.position != exitArea.position)
        {
            // Move to the exit area
            transform.position = Vector2.MoveTowards(transform.position, exitArea.position, moveSpeed * Time.deltaTime);

            yield return null;
        }

        // Display a message that the NPC has reached the exit area
        Debug.Log(gameObject.name + " has reached the exit area and disappeared.");

        // Disable the NPC's GameObject
        gameObject.SetActive(false);
    }

    public void chack()
    {
        checkQuest.SetActive(true);
    }

    public void confirmQuest()
    {
        UIcheck.SetActive(false);
        Vector3 scale = transform.localScale;
        // Flip the object along the X-axis by negating the X scale
        scale.x = -scale.x;
        // Apply the new scale to the object
        transform.localScale = scale;

        confirm = chackQuestManager.confirmValue;
        if (confirm == 1)
        {
            Debug.Log(" Confirm Quest ");

            StartCoroutine(MoveToExitArea());
        }
        else if (confirm == 2)
        {
            Debug.Log("Reject Quest ");
            InventoryManager.Instance.Add(adventurer.currentQuest);
            adventurer.currentQuest = null;
            StartCoroutine(MoveToExitArea());
        }
    }
}