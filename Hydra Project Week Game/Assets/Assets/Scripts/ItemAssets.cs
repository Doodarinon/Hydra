using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    // Add sprites here (for inventory icons)!
      public Sprite baseballbatSprite;
      public Sprite healthpackSprite;
}
