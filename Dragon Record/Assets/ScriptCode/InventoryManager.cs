using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Toggle EnableRemove;
    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
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
            if (InventoryItem != null && ItemContent != null)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);

                // Check if obj is not null before accessing its components.
                if (obj != null)
                {
                    var itemNameTransform = obj.transform.Find("ItemName");

                    // Check if itemNameTransform is not null before accessing its component.
                    var itemName = itemNameTransform?.GetComponent<Text>();

                    var itemIconTransform = obj.transform.Find("ItemIcon");

                    // Check if itemIconTransform is not null before accessing its component.
                    var itemIcon = itemIconTransform?.GetComponent<Image>();

                    var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

                    if (itemName != null && itemIcon != null)
                    {
                        itemName.text = item.itemName;
                        itemIcon.sprite = item.icon;
                    }
                    else if (EnableRemove.isOn)
                    {
                        removeButton.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.LogWarning("ItemName or ItemIcon not found in the InventoryItem prefab.");
                    }
                }
                else
                {
                    Debug.LogWarning("InventoryItem not instantiated properly.");
                }
            }
            else
            {
                Debug.LogWarning("InventoryItem or ItemContent not assigned in the inspector.");
            }
        }
        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
