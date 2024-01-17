using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPickup : MonoBehaviour
{
    public QuestLevel QuestLevel;

    void Pickup()
    {
        QuestBoradManager.Instance.Add(QuestLevel);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
