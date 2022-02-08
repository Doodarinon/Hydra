using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Inventory
{
    private List<Item> itemList;

        public Player_Inventory()
        {
            itemList = new List<Item>();

            AddItem(new Item { itemType = Item.ItemType.BaseBallBat, amount = 1 });
            Debug.Log(itemList.Count);
        }
    //Allows player to pick up an item.
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
    /*private GameObject inventoryMenu;
    private bool pressed = false;*/

    void Start()
    {
        //inventoryMenu = gameObject.transform.Find("InventoryMenu").gameObject;
    }

    void Update()
    {
        // If button has already been pressed, don't update.
        /*if (pressed)
            return;

        // Raycast mouse position.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // If ray hits something, store data in 'hit'.*/
    }

    // For weapons.
    public void Equip()
    {

    }
     // For all items.
    public void Drop()
    {

    }
    //For healthpacks.
    public void Use()
    {

    }
}
