using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages items and their functionalities.
/// </summary>
public class Item
{
    /// <summary>
    /// An enum in which an item is declared. This is where you add more item types!
    /// </summary>
    public enum ItemType
    {
        Healthpack,
    }

    public ItemType itemType;
    
    public int amount;
    public int maxAmount = 10;

    /// <summary>
    /// Assigns a sprite to each item to be displayed in the inventory.
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
      {
        switch (itemType)
        {
            default:
            // If item is a health pack - assign healthpack sprite.
            case ItemType.Healthpack: return ItemAssets.Instance.healthpackSprite;
        }
    }
    /// <summary>
    /// Is the item stackable or not?
    /// </summary>
    /// <returns></returns>
    public bool IsStackable()
    {
        switch (itemType)
        {
            default:
            // IS stackable.
            case ItemType.Healthpack:
                return true;
        }
    }

}
