using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * TO DO:
 * make a take back item
 * stop the user from over using items
 */
public class Inventory : MonoBehaviour
{
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;

    void Start()
    {
        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
            );
    }
}
