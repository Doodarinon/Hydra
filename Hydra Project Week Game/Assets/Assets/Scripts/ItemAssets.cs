using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages item assets such as allowing for adding sprites.
/// </summary>
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Used to instantiate/spawn items.
    public Transform prefabItemInWorld;

    // Add sprites here (for inventory icons)!
      public Sprite healthpackSprite;
}
