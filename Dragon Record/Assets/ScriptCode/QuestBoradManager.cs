using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoradManager : MonoBehaviour
{
    public static QuestBoradManager Instance;
    public List<QuestLevel> QuestLevels = new List<QuestLevel>();

    public Transform QuestLevelContent;
    public GameObject QuestLevel;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(QuestLevel questLevel)
    {
        QuestLevels.Add(questLevel);
    }

    public void Remove(QuestLevel questLevel)
    {
        QuestLevels.Remove(questLevel);
    }

    public void ListQuest()
    {
        foreach (var questLevel in QuestLevels)
        {
            GameObject obj = Instantiate(QuestLevel, QuestLevelContent);
            var ItemName = obj.transform.Find("QuestLevel/ItemName").GetComponent<Text>();
            var ItemIcon = obj.transform.Find("QuestLevel/ItemIcon").GetComponent<Image>();

            ItemName.text = questLevel.itemName;
            ItemIcon.sprite = questLevel.icon;
        }
    }
}
