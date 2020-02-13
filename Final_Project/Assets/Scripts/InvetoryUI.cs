using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvetoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject invetoryUI;
    Inventory inventory;
    public KeyCode interactKey = KeyCode.Q;
    InventorySlot[] slots;
    // Start is called before the first frame update
    void Start()
    {
       inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            invetoryUI.SetActive(!invetoryUI.activeSelf);
            Debug.Log("pressed q");
        }
    }
    void UpdateUI ()
    {
        Debug.Log("Update UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
