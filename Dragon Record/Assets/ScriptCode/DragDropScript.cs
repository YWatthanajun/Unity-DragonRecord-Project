using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    Transform parentAfterDrag;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

    }

    public void OnBeginDrag(PointerEventData eventData) //กดคลิกเพื่อลาก
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f; //เฟรมในการลาก วัตถุซ้อนกัน 6 ชิ้น
        canvasGroup.blocksRaycasts = false; //ตั้งค่าให้บล็อก Raycast วัตถุอื่นตอนคลิก
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root); //ย้าย GameObject ไปยัง Parent root 
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)  //คลิกค้างตอนกำลังลาก
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // ลาก GameObject ไปพร้อมกับเมาส์
    }

    public void OnEndDrag(PointerEventData eventData) //ปล่อยปุ่มคลิกซ้าย
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true; //ตั้งค่าให้เลิกบล็อก Raycast วัตถุอื่นตอนปล่อย
        transform.SetParent(parentAfterDrag); //ย้าย GameObject ไปยัง Parent เดิม
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
