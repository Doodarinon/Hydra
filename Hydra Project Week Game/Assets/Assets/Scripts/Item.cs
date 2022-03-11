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
        BaseBallBat,
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
            case ItemType.BaseBallBat: return ItemAssets.Instance.baseballbatSprite;
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
            case ItemType.Healthpack:
                return true;
            case ItemType.BaseBallBat:
                return false;
        }
    }

}
