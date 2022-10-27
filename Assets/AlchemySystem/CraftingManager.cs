using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CraftingManager : MonoBehaviour
{
    public List<Item> CraftingItems;
    public List<GameObject> CraftingSlots;
    // Update is called once per frame
    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("CraftingSlot"))
        {
            CraftingSlots.Add(item);
        }
    }

    public void Add(Item item)
    {
        CraftingItems.Add(item);
    }

}
