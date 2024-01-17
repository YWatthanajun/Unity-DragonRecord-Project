using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestSloth : MonoBehaviour, IDropHandler 
{

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) //ตรวจสอบว่า มีวัตถุที่ลากจริงรึเปล่า
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; // ย้ายตำแหน่ง GameObject ไปยังช่อง QuestSloth
        }
    }

}
