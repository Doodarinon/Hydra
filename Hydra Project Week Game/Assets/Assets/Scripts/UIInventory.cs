using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages the visual aspects of the player's inventory.
/// </summary>
public class UIInventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;
    private Transform background;
    private bool state;

    // Using getter and setter to allow bool to be accessed outside, but not be configurated in edit mode.
    public bool State
    {
        get { return state; }
        set { state = value; }
    }

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

        float x = 0;
        float y = 0;
        // Distance between slots.
        float itemSlotCellsize = 60f;
        // For every existing item, create an item slot.
        foreach (Item item in inventory.GetItemList())
        {

            RectTransform itemslotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemslotRectTransform.gameObject.SetActive(true);

            itemslotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellsize, y * itemSlotCellsize);
            Image image = itemslotRectTransform.Find("itemImage").GetComponent<Image>();

            // Display sprite designated to specific item.
            image.sprite = item.GetSprite();

            // Adds a listener to every item that goes into the player's inventory.
            itemslotRectTransform.GetComponent<Button>().onClick.AddListener(() => { inventory.UseItem(item); });

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
           if(x > 2)
           {
               x = 0;
               y--;
           }
        }
    }
}
