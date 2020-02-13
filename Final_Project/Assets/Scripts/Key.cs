using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Key", menuName = "Inventory/Key")]
public class Key : Item
{
    
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public override void Use()
    {
        base.Use();
        
        RemoveFromInventory();
        
    }
}

