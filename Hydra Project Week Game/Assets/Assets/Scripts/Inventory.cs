using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Internal managing of the player's inventory.
/// </summary>
public class Inventory
{
    // Decides what action to take after an inventory change.
    public event EventHandler OnItemListChange;
    // Creates list to track items in inventory!
    private List<Item> itemList;

    /// <summary>
    /// Declares the player's inventory.
    /// </summary>
    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.BaseballBat, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        Debug.Log("Added " + itemList.Count + " item(s).");
    }

    /// <summary>
    /// Adds an item to the player's inventory.
    /// </summary>
    /// <param name="item"></param>
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
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Removes an item from the player's inventory.
    /// </summary>
    /// <param name="item"></param>
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
            // If item less than/equal to 0, no item will be removed.
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        // Otherwise, the item used will be removed.
        else
        {
            itemList.Remove(item);
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Calls on item list, can be used to for example compare items or add new items.
    /// </summary>
    /// <returns></returns>
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
