using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePanel1 : MonoBehaviour
{
    public GameObject GuidePanel;

    public void OpenPanel()
    {
        if(GuidePanel != null)
        {
            GuidePanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    public void CloseGuideUIPanel()
    {
        GuidePanel.SetActive(false);
        Time.timeScale = 1f; 
    }

}
