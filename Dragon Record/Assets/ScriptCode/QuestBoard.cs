using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public float interactRange;
    public GameObject questUIPanel;
  


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("questBoard"))
                {
                    // Check if the player is within the interact range
                    Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
                    if (playerCollider != null)
                    {
                        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactRange);
                        foreach (Collider2D hitCollider in hitColliders)
                        {
                            if (hitCollider == playerCollider)
                            {
                                audioSource.PlayOneShot(audioClip);
                                Debug.Log("Clicked on: " + hit.collider.gameObject.name);

                                // Show the quest UI panel and pause the game
                                questUIPanel.SetActive(true);
                                Time.timeScale = 0f;
                                break;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("Player is missing a Collider2D component");
                    }
                }
                // Perform desired action when object is clicked
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    public void CloseQuestUIPanel()
    {
        questUIPanel.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }

 
}