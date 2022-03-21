using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Internal managing of the player's inventory.
/// </summary>
public class Inventory
{
    // Creates list to track items in inventory!
    public event EventHandler OnItemListChange;
    private List<Item> itemList;

    /// <summary>
    /// Declares the player's inventory.
    /// </summary>
    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        /*Debug.Log("Added " + itemList.Count + " item(s).");*/
    }

    /// <summary>
    /// Adds an item to the player's inventory.
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
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
            // Makes sure player has enough items to remove.
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

    /// <summary>
    /// Calls on item list, can be used to for example compare items or add new items.
    /// </summary>
    /// <returns></returns>
    public List<Item> GetItemList()
    {
        return itemList;
    }
}
