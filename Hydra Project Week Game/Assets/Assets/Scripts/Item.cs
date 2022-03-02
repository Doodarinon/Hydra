using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages items and their abilities, such as being stackable or not.
/// </summary>
public class Item
{ 
    /// <summary>
    /// Declaration of each existing item type.
    /// </summary>
    public enum ItemType
    {
        BaseBallBat,
        Healthpack,
    }

    public ItemType itemType;
    public int amount;

    /// <summary>
    /// Assigns an inventory icon (sprite) to each existing item.
    /// </summary>
    public Sprite GetSprite()
      {
        switch (itemType)
        {
            default:
            // If item is a baseball bat - assign baseball bat sprite.
            case ItemType.BaseBallBat: return ItemAssets.Instance.baseballbatSprite;
            // If item is a health pack - assign health pack sprite.
            case ItemType.Healthpack: return ItemAssets.Instance.healthpackSprite;
        }
    }
    /// <summary>
    /// Which items are stackable and which are not?
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
            case ItemType.BaseBallBat:
                return false;
        }
    }

}
