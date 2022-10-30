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
            item = null;
            UpdateGraphic();
        }
    }

    public void AddItemToSlot()
    {
        if (item == null)
        {
            item = IPlayerMouse.Item;
            IPlayerMouse.Item = null;
        }
        else
        {
            if (IPlayerMouse.Item == null)
            {
                IPlayerMouse.Item = item;
                item = null;
            }
        }
        UpdateGraphic();
        ICraftingManager.UpdateCraftingList();
    }

    private bool CanUseItem()
    {
        return (item != null);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            descriptionText.text = item.description;
            nameText.text = item.name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (item != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }
    }

    public bool AddItem(Item Pitem)
    {
        if (item != null)
        {
            return false;
        }
        item = Pitem;
        UpdateGraphic();
        return true;
    }
}
