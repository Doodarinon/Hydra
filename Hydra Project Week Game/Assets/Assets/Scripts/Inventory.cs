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
    private Action<Item> useItemAction;

    private int capacity = 6;

    /// <summary>
    /// Does the inventory have capacity to store another item?
    /// </summary>
    /// <returns></returns>
    public bool hasCapacity()
    {
        if(capacity > itemList.Count)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Declares the player's inventory.
    /// </summary>
    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();
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
                // Inventory item cannot surpass the max amount of stacked items. If it does, then a new slot will be created.
                if (inventoryItem.itemType == item.itemType && inventoryItem.amount < item.maxAmount)
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                    //Debug.Log("Amount has increased");
                }             
            }
            if (!itemAlreadyInInventory)
            {
                itemList.Add(item);
                //Debug.Log("Added new stackable item");
            }
        }
        else
        {
            itemList.Add(item);
            //Debug.Log("Added new non-stackable item");
        }
        OnItemListChange?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Allows the player to use the item they click on.
    /// </summary>
    public void UseItem(Item item)
    {
        useItemAction(item);
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
