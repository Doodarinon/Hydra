using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // References to each item type.
    public enum ItemType
    {
        BaseBallBat,
        Healthpack,
    }

    public ItemType itemType;
    public int amount;

    // Assigns sprite to each item. This will only be displayed in the inventory.
    public Sprite GetSprite()
      {
        switch (itemType)
        {
            default:
            case ItemType.BaseBallBat: return ItemAssets.Instance.baseballbatSprite;
            case ItemType.Healthpack: return ItemAssets.Instance.healthpackSprite;
        }
    }
    // Decides whether or not an item is stackable.
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
