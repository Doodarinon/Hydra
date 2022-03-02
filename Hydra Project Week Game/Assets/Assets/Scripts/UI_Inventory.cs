using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the visual aspects of the inventory system.
/// </summary>
public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform background;
    /// <summary>
    /// Button for using an item. Drag "itemImage" (which is a button) into this slot.
    /// </summary>
    public Button useItemButton;
    bool state;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        background = transform.Find("Background");
    }

    /// <summary>
    /// Shows or hides inventory depending on what button the player clicks.
    /// </summary>
    public void ShowHide()
    {
        state = !state;
        background.gameObject.SetActive(state);
        itemSlotContainer.gameObject.SetActive(state);
    }

    /// <summary>
    /// Sets inventory to current state.
    /// </summary>
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChange += Inventory_OnItemListChange;

        RefreshInventoryItems();
    }

    /// <summary>
    /// When a change in the inventory occurs, this event will be called and refresh the inventory to sync with the current state of the inventory.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    /// <summary>
    /// Keeps the inventory updated to current state, both visually and function-wise.
    /// </summary>
    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        // Code only for the inventory's visualization.
        float x = -0.4f;
        float y = 0.4f;

        // Distance between slots.
        float itemSlotCellsize = 70f;

        // For every existing item, create an item slot.
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemslotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemslotRectTransform.gameObject.SetActive(true);

            // When item is clicked, the player use said item.
            useItemButton.onClick.AddListener(() => GetComponent<Player_Controller>().UseItem(item));

            itemslotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellsize, y * itemSlotCellsize);
            Image image = itemslotRectTransform.Find("itemImage").GetComponent<Image>();
            // Each item has their own assigned sprite. The item image is in turn determinded by this.
            image.sprite = item.GetSprite();

            TextMeshProUGUI text = itemslotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            // If item is stackable and the player has more than one of that item.
            if (item.amount > 1 && item.IsStackable())
            {
                text.SetText(item.amount.ToString());
            }
            // Otherwise, the text is empty.
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
}
