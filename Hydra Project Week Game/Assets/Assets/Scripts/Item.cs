using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages items and their functionalities.
/// </summary>
public class Item
{
    /// <summary>
    /// List of each type of item.
    /// </summary>
    public enum ItemType
    {
        BaseballBat,
        Healthpack,
    }

    public ItemType itemType;
    public int amount;

    /// <summary>
    /// Assigns a sprite to each item to be displayed in the inventory.
    /// </summary>
    /// <returns></returns>
    public Sprite GetSprite()
      {
        switch (itemType)
        {
            default:
            // If item is a baseball bat - assign baseball bat sprite.
            case ItemType.BaseballBat: return ItemAssets.Instance.baseballbatSprite;
            // If item is a health pack - assign health pack sprite.
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

            // Is NOT stackable.
            case ItemType.BaseballBat:

                return false;
        }
    }

}
