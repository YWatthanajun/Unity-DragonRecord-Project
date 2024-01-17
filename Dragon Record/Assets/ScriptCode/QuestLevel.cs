using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName = "Item/Create New Item")]
public class QuestLevel : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;
}
