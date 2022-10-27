using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public Sprite icon;
    public string description = "";
    public bool isConsumable = false;
    public void Use()
    {
        Debug.Log("Used item: " + name + " - " + description);
    }

    public int Str = 0;
    public int Dex = 0;
    public int Int = 0;
    public int Def = 0;
    public int Sta = 0;
    public int Healing = 0;
    public int Health = 0;
    public int ManaRegen = 0;
    public int Mana = 0;
}
