using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AdventurerInfo : MonoBehaviour
{
    public Adventurer adventurer;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI questText;

    void Update()
    {
        // Update the level text
        levelText.text = "Level: " + adventurer.level;

        // If the adventurer has a current quest, update the quest text
        if (adventurer.currentQuest != null)
        {
            questText.text = "Quest: " + adventurer.currentQuest.QuestName;
        }
        else if (adventurer.currentQuest == null)
        {
            questText.text = "Quest: None";
        }
    }
}
