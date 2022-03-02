using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages visual assets for each item which will be displayed in the inventory.
/// </summary>
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Add sprites here (for inventory icons)!
      public Sprite baseballbatSprite;
      public Sprite healthpackSprite;
}
