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

    public Sprite GetSprite()
      {
        switch (itemType)
        {
            default:
            case ItemType.BaseBallBat: return ItemAssets.Instance.baseballbatSprite;
            case ItemType.Healthpack: return ItemAssets.Instance.healthpackSprite;
        }
    }

}
