using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Item item = null;
    private CraftingManager ICraftingManager;
    private PlayersMouse IPlayerMouse;

    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;

    [SerializeField]
    Image itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        ICraftingManager = GameObject.FindObjectOfType<CraftingManager>();
        IPlayerMouse = GameObject.FindObjectOfType<PlayersMouse>();
        UpdateGraphic();
    }

    //Change Icon and count
    public void UpdateGraphic()
    {
        if (item == null)
        {
            itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 0.0f);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1.0f);
            itemIcon.sprite = item.icon;
        }
    }

    public void DeleteItemInSlot()
    {
        if (item != null)
        {
            ICraftingManager.CraftingItems.Remove(item);
            item = null;
            UpdateGraphic();
        }
    }

    public void AddItemToSlot()
    {
        if (item == null && IPlayerMouse.Item != null && IPlayerMouse.Item.isCraftingIngredient)
        {
            item = IPlayerMouse.Item;
            ICraftingManager.CraftingItems.Add(item);
            IPlayerMouse.Item = null;
        }
        else if (IPlayerMouse.Item == null)
        {
            IPlayerMouse.Item = item;
            ICraftingManager.CraftingItems.Remove(item);
            item = null;
        }
        UpdateGraphic();
    }
}
