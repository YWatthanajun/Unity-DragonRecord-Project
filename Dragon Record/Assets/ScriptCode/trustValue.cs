using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class trustValue : MonoBehaviour
{
    public int value;
    public int maxValue;
    public TextMeshProUGUI trustValueText;

    // Update is called once per frame
    void Update()
    {
        trustValueText.text = "trust : " + value + " / " + maxValue;
        if (maxValue <= value)
        {
            value = value - maxValue;
            maxValue = maxValue + 25;
        }
    }

    public void minus()
    {
        int randomMinus = Random.Range(5, 35);
        value = value - randomMinus;
    }

    public void add()
    {
        int randomAdd = Random.Range(20, 50);
        value = value + randomAdd;
    }
}