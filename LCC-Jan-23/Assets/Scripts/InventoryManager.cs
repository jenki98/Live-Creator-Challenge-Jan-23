using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; set; }
    public List<Item> items = new List<Item>();
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }

    }
    public void AddInventoryItem(ItemSO itemSO)
    {
        Item item = new Item();
        item.Name = itemSO.ItemName;
        item.Icon = itemSO.ItemIcon;

        items.Add(item);

        foreach (Item i in items)
        {
            Debug.Log(i.Name);
        }
    }

    public void RemoveInventoryItem()
    {

    }
}
