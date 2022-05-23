using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
public int id;
public string itemName;
public string despriction;
public Sprite image;
public int hp;
public bool stillpoisoned;

}
