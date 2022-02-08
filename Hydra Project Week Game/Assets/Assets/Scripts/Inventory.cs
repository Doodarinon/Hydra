using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChange;
    // Creates list to track items in inventory!
    private List<Item> itemList;

        public Inventory()
        {
            itemList = new List<Item>();

            AddItem(new Item { itemType = Item.ItemType.BaseBallBat, amount = 1 });
            AddItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
            Debug.Log(itemList.Count);
        }
    // Allows the player to add items to their inventory.
    public void AddItem(Item item)
    {
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    // For weapons.
    public void Equip()
    {

    }
     // For all items.
    public void Drop()
    {

    }
    //For healthpacks.
    public void Use()
    {

    }
}
