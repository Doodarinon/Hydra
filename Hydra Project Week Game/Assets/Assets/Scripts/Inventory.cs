using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Creates list to track items in inventory!
    public event EventHandler OnItemListChange;
    private List<Item> itemList;

    // Gives the player their inventory.
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.BaseBallBat, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        Debug.Log("Added " + itemList.Count + " item(s).");
    }

    // Allows the player to add items to their inventory.
    public void AddItem(Item item)
    {
        // If the item is stackable.
        if (item.IsStackable())
        {
            bool itemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }             
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
                Debug.Log("Added new stackable item");
            }
        }
        // If the item is NOT stackable.
        else
        {
            itemList.Add(item);
            Debug.Log("Added new non-stackable item");
        }
        // Invokes even OnItemListChange, which refreshes the inventory after a change.
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    // Allows the player to remove an item.
    public void RemoveItem(Item item)
    {
        // If item is stackable it counts the amount you have (if any) to then remove only one (if you have multiple of the same).
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }        
            }
            // Makes sure player actually has enough items to remove.
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
