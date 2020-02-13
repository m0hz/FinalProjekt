using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public delegate void OnEquipmentChanged(EquipMent newItem, EquipMent oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;
void Start()
    {
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new EquipMent[numSlots];
    }

    public void Awake()
    {
        instance = this;
    }
    EquipMent[] currentEquipment;
    
    public void Equip (EquipMent newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        EquipMent oldItem = null;
        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];

            inventory.Add(oldItem);
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currentEquipment[slotIndex] = newItem;
    }
    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            EquipMent oldItem = currentEquipment[slotIndex];
                inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
        
    }
    public void UnequipAll ()
    {
        for (int i = 0; i <currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
