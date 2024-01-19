using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartADayButton : MonoBehaviour
{
    public NPCMovement npcMovement;
    public AudioClip soundEffect;

    public AudioSource audioSource;

    public void OnClick()
    {
        // Play the sound effect
        audioSource.clip = soundEffect;
        audioSource.Play();

        // Start the day
        npcMovement.StartDay();
    }
}