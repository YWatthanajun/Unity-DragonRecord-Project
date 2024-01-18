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

                    if (itemName != null && itemIcon != null)
                    {
                        itemName.text = item.itemName;
                        itemIcon.sprite = item.icon;
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
    }
}
