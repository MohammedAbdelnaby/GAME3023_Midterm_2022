using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<Item> CraftingItems;
    public List<CraftingSlot> CraftingSlots;
    private PlayersMouse IPlayerMouse;
    // Update is called once per frame
    void Start()
    {
        IPlayerMouse = GameObject.FindObjectOfType<PlayersMouse>();
        foreach (CraftingSlot item in GameObject.FindObjectsOfType<CraftingSlot>())
        {
            CraftingSlots.Add(item);
        }
    }

    public void Add(Item item)
    {
        for (int i = 0; i < CraftingSlots.Count; i++)
        {
            if (CraftingSlots[i].AddItem(item))
            {
                return;
            }
        }
    }
    public void UpdateCraftingList()
    {
        for (int i = 0; i < CraftingSlots.Count; i++)
        {
            CraftingItems[i] = CraftingSlots[i].item;
        }
    }

    private void ResetCraftingSlots()
    {
        for (int i = 0; i < CraftingItems.Count; i++)
        {
            CraftingSlots[i].DeleteItemInSlot();
        }
        UpdateCraftingList();
    }

    public void Craft()
    {
        Item[] CraftableItems = Resources.LoadAll<Item>("Items/Craftables");
        foreach (Item CItems in CraftableItems)
        {
            int count = 0;
            foreach (Item IItem in CraftingItems)
            {
                foreach (Item Ingredient in CItems.Ingredients)
                {
                    if (IItem == Ingredient)
                    {
                        count++;
                    }
                }
            }
            if (count == CItems.Ingredients.Length)
            {
                IPlayerMouse.Item = CItems;
                ResetCraftingSlots();
                return;
            }
        }
    }

}
