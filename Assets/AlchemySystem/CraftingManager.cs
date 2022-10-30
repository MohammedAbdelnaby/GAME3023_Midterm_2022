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
    private Item[] CraftableItems;
    // Update is called once per frame
    void Start()
    {
        CraftableItems = Resources.LoadAll<Item>("Items/Craftables");
        IPlayerMouse = GameObject.FindObjectOfType<PlayersMouse>();
        foreach (CraftingSlot item in GameObject.FindObjectsOfType<CraftingSlot>())
        {
            CraftingSlots.Add(item);
        }
    }

    private void ResetCraftingSlots()
    {
        for (int i = 0; i < CraftingSlots.Count; i++)
        {
            CraftingSlots[i].DeleteItemInSlot();
        }
    }
    public void Craft()
    {
        foreach (Item CItems in CraftableItems)
        {
            if (CraftingItems.Count != CItems.Ingredients.Length)
                continue;
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
