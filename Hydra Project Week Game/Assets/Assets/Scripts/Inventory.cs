using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChange;
    // Creates list to track items in inventory!
    private List<Item> itemList;
    private Action<Item> useItemAction;

    // Gives the player their inventory.
    public Inventory(Action<Item> useItemAction)
    {
        this.useItemAction = useItemAction;
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.BaseBallBat, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        Debug.Log("Added " + itemList.Count + " item(s).");
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

    // Allows the player to remove an item.
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

    public void UseItem(Item item)
    {
        useItemAction(item);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
