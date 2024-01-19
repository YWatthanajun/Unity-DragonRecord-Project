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
    public QueueManager queue;
    public bool start;
    public int isStart;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartDay()
    {
        start = true;
    }
    private void Update()
    {
        if (adventurer.Queue == queue.QueueAdven && start == true && isStart == 0)
        {
            isStart = 1;
            StartCoroutine(MoveToQuestBoard());
        }
    }

    IEnumerator MoveToQuestBoard()
    {
        //if (anim == null)
        //{
        //    Debug.LogError("Animator is not assigned to NPCMovement script.");
        //    yield break;
        //}

        //Debug.Log("Triggering PickUp_NPC_01 animation.");
        //anim.SetTrigger("PickUp_NPC_01");

        while (adventurer.currentQuest == null)
        {
            // Move to the quest board to pick up a quest
            transform.position = Vector2.MoveTowards(transform.position, questBoard.position, moveSpeed * Time.deltaTime);
            anim.SetBool("isWalk", true);
            if (transform.position == questBoard.position)
            {
                anim.SetBool("isWalk", false);
                if (InventoryManager.Instance.Items.Count == 0)
                {
                    Debug.Log(" NoQuest ");
                    yield return new WaitForSeconds(3.0f);
                    yield return null;
                    confirmQuest();
                }
                else
                {
                    // Pick up a random quest from the quest board
                    Item quest = InventoryManager.Instance.Items[Random.Range(0, InventoryManager.Instance.Items.Count)];

                    // Assign the quest to the Adventurer's currentQuest variable
                    adventurer.currentQuest = quest;
                    InventoryManager.Instance.Remove(quest);

                    // Display a message that the NPC has picked up a quest
                    Debug.Log(gameObject.name + " has picked up the quest: " + quest.QuestName);

                    // Wait for 3 seconds
                    yield return new WaitForSeconds(3.0f);
                }
            }
            yield return null;
        }
        anim.SetBool("isPickUp", false);
        // Move to the guild counter to have the player check the quest level
        StartCoroutine(MoveToGuildCounter());
    }

    IEnumerator MoveToGuildCounter()
    {
        anim.SetBool("isWalk", true);
        //adventurerInfo.questText.text("");
        while (transform.position != guildCounter.position)
        {
            // Move to the guild counter
            transform.position = Vector2.MoveTowards(transform.position, guildCounter.position, moveSpeed * Time.deltaTime);

            yield return null;
        }
        anim.SetBool("isWalk", false);
        // Display a message that the NPC has reached the guild counter
        Debug.Log(gameObject.name + " has reached the guild counter with the quest: " + adventurer.currentQuest.QuestName);
        checkQuest.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        yield return null;
        chack();

        // Move to the exit area
    }

    IEnumerator MoveToExitArea()
    {
        anim.SetBool("isWalk", true);
        Transform childTransform = transform.Find("Root"); // Replace with the actual child object's name
        if (childTransform != null)
        {
            Vector3 childScale = childTransform.localScale;
            // Flip the object along the X-axis by negating the X scale
            childScale.x = -childScale.x;
            // Apply the new scale to the child object
            childTransform.localScale = childScale;
        }

        yield return new WaitForSeconds(1.0f);
        while (transform.position != exitArea.position)
        {
            // Move to the exit area
            transform.position = Vector2.MoveTowards(transform.position, exitArea.position, (moveSpeed * 1.75f) * Time.deltaTime);

            yield return null;
        }

        // Display a message that the NPC has reached the exit area
        Debug.Log(gameObject.name + " has reached the exit area and disappeared.");
        anim.SetBool("isWalk", false);
        queue.Queue();
        // Disable the NPC's GameObject
        gameObject.SetActive(false);
    }

    public void chack()
    {
        Time.timeScale = 0f;
        checkQuest.SetActive(true);
    }

    public void confirmQuest()
    {
        anim.SetBool("isPickUp", false);
        UIcheck.SetActive(false);
        confirm = chackQuestManager.confirmValue;
        if (confirm == 1)
        {
            Debug.Log(" Confirm Quest ");
            chackQuestManager.ResetValue();
            StartCoroutine(MoveToExitArea());
        }
        else if (confirm == 2)
        {
            Debug.Log("Reject Quest ");
            InventoryManager.Instance.Add(adventurer.currentQuest);
            chackQuestManager.ResetValue();
            adventurer.currentQuest = null;
            StartCoroutine(MoveToExitArea());
        }
    }
}