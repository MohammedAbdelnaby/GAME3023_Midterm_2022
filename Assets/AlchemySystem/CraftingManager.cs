using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<Item> CraftingItems;
    public List<CraftingSlot> CraftingSlots;
    // Update is called once per frame
    void Start()
    {
        foreach (CraftingSlot item in GameObject.FindObjectsOfType<CraftingSlot>())
        {
            CraftingSlots.Add(item);
        }
    }

    public void Add(Item item)
    {
        CraftingItems.Add(item);
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

}
