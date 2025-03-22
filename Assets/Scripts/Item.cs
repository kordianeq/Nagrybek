using UnityEngine;

public enum E_Rarity
{
    common,
    rare,
    epic,
    legendary
}
public class Item : MonoBehaviour
{
    public string itemName;
    public E_Rarity rarity;

}
