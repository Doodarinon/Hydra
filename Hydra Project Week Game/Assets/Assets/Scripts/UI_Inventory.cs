using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the visual aspects of the player's inventory.
/// </summary>
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform background;
    bool state;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        background = transform.Find("Background");
    }

    /// <summary>
    /// Shows or hides inventory on button click.
    /// </summary>
    public void ShowHide()
    {
        state = !state;
        background.gameObject.SetActive(state);
        itemSlotContainer.gameObject.SetActive(state);
    }

    /// <summary>
    /// Sets inventory to current state in order to keep it updated.
    /// </summary>
    /// <param name="inventory"></param>
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChange += Inventory_OnItemListChange;

        RefreshInventoryItems();
    }

    /// <summary>
    /// When a change in the inventory occurs, do a refresh.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    /// <summary>
    /// Refreshes the inventory to keep it updated.
    /// </summary>
    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        float x = -0.4f;
        float y = 0.4f;
        // Distance between slots.
        float itemSlotCellsize = 70f;
        // For every existing item, create an item slot.
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemslotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemslotRectTransform.gameObject.SetActive(true);

            itemslotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellsize, y * itemSlotCellsize);
            Image image = itemslotRectTransform.Find("itemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI text = itemslotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                text.SetText(item.amount.ToString());
            }
            else
            {
                text.SetText("");
            }

           x++;
           if(x > 4)
           {
               x = -0.4f;
               y++;
           }
        }
    }
    /// <summary>
    /// Allows the player to use the item they click on.
    /// </summary>
    /*public void UseItem()
    {
        inventory.RemoveItem(new Item { itemType = Item.ItemType.Healthpack, amount = 1 });
        GetComponent<PlayerHealth>().currentPlayerHealth += 10;

        Debug.Log("Item has been used.");
    }*/
}
