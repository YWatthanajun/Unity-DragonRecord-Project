using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public int QueueAdven;
    public GameObject endDay;

    public void Queue()
    {
        QueueAdven++;
    }
    private void Update()
    {
        if (QueueAdven == 5)
        {
            Time.timeScale = 0f;
            endDay.SetActive(true);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
