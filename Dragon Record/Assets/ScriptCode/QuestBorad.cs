using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBorad : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
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
                    audioSource.PlayOneShot(audioClip);
                    Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                }              
                // Perform desired action when object is clicked
            }
        }
    }
}
