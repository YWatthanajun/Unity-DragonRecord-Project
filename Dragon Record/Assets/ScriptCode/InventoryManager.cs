using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItemPrefab;
    public Toggle EnableRemove;


    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        ListItems();
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems()
    {
        // Clear existing UI items before updating.
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in Items)
        {
            if (InventoryItemPrefab != null && ItemContent != null)
            {
                GameObject obj = Instantiate(InventoryItemPrefab, ItemContent);

                if (obj != null)
                {
                    var itemName = obj.transform.Find("ItemName")?.GetComponent<Text>();
                    var itemIcon = obj.transform.Find("ItemIcon")?.GetComponent<Image>();
                    var removeButton = obj.transform.Find("RemoveButton")?.GetComponent<Button>();

                    if (itemName != null && itemIcon != null)
                    {
                        itemName.text = item.QuestName;
                        itemIcon.sprite = item.icon;
                    }                   
                }
                else
                {
                    Debug.LogWarning("InventoryItemPrefab not instantiated properly.");
                }
            }
            else
            {
                Debug.LogWarning("InventoryItemPrefab or ItemContent not assigned in the inspector.");
            }
        }
    }
    //public void EnableItemsRemove()
    //{
    //    if (EnableRemove.isOn)
    //    {
    //        foreach (Transform item in ItemContent)
    //        {
    //            item.Find("RemoveButton").gameObject.SetActive(true);
    //        }
    //    }
    //    else
    //    {
    //        foreach (Transform item in ItemContent)
    //        {
    //            item.Find("RemoveButton").gameObject.SetActive(false);
    //        }
    //    }
    //}

    //public void SetInventoryItems()
    //{
    //    InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

    //    for (int i = 0; i < Items.Count; i++)
    //    {
    //        InventoryItems[i].AddItem(Items[i]);
    //    }
    //}
}

