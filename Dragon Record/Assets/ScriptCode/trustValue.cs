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
    }

    public void minus()
    {
        int randomMinus = Random.Range(5, 35);
        value = value - randomMinus;
    }
}
