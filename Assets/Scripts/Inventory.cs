using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Shovel,
    Vision,
    Rope,
    Bucket,
    Stone,
    Mineral,
    Artifact
}

public class Inventory : MonoBehaviour
{
    public List<ItemType> items;


    public bool Contains(ItemType item)
    {
        return items.Contains(item);
    }

    public void AddItem(ItemType newItem)
    {
        items.Add(newItem);
    }

    public void RemoveItem(ItemType item)
    {
        items.Remove(item);
    }
}