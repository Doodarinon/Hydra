using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages spawning of usable items.
/// </summary>
public class ItemInWorld : MonoBehaviour
{
    private Item item;
    /// <summary>
    /// Spawn an item into the world.
    /// </summary>
    public static ItemInWorld SpawnItemInWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.prefabItemInWorld, position, Quaternion.identity);

        ItemInWorld itemInWorld = transform.GetComponent<ItemInWorld>();
        itemInWorld.SetItem(item);

        return itemInWorld;
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
