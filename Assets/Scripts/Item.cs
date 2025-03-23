using UnityEngine;

public enum E_Rarity
{
    common,
    rare,
    epic,
    legendary
}
public enum E_ItemType
{
    skinner,
    normal
}
public class Item : MonoBehaviour
{
    public string itemName;
    public E_Rarity rarity;
    public E_ItemType type;
}
