using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform background;
    public Button useItemButton;
    bool state;

    // On awake, find existing objects.
    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        background = transform.Find("Background");
    }

    // Shows or hides inventory depending on what button the player clicks.
    public void ShowHide()
    {
        state = !state;
        background.gameObject.SetActive(state);
        itemSlotContainer.gameObject.SetActive(state);
    }

    // Sets inventory to current state.
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChange += Inventory_OnItemListChange;

        RefreshInventoryItems();
    }

    // When a change in the inventory occurs, refresh.
    private void Inventory_OnItemListChange(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    // Updates the inventory.
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

            useItemButton.onClick.AddListener(() => GetComponent<Player_Controller>().UseItem(item));

            itemslotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellsize, y * itemSlotCellsize);
            Image image = itemslotRectTransform.Find("itemImage").GetComponent<Image>();
            image.sprite = item.GetSprite();

            TextMeshProUGUI text = itemslotRectTransform.Find("amountText").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1 && item.IsStackable())
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
}
