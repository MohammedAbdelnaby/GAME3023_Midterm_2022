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
        UpdateGraphic();
    }

    //Change Icon and count
    void UpdateGraphic()
    {
        if (item == null)
        {
            itemIcon.gameObject.SetActive(false);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.sprite = item.icon;
            itemIcon.gameObject.SetActive(true);
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
