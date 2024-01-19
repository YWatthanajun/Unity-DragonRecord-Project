using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string QuestName;
    public int levelQuest;
    public Sprite icon;
    public string description;
    public int reward;
}
