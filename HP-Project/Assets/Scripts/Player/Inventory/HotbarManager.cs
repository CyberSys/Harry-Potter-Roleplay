using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{

    public InventoryManager inventory;
    public PlayerController controller;
    private int currentSlot = 0;
    KeyCode[] keyCodes = {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };
    
    // Update is called once per frame
    void Update()
    {
        //assigns spell's image to assigned hotbar slot
        for (int i = 0; i < inventory.hotbarSpells.Count; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = inventory.hotbarSpells[i].image;
        }
        //loops through number keys
        for (int i = 0; i < keyCodes.Length; i++)
        {
            //if a number key
            if (Input.GetKey(keyCodes[i]))
            {
                //assign current slot and spell prefab
                currentSlot = i;
                controller.spell = inventory.hotbarSpells[i].spellPrefab;
            } else
            {
                //otherwise greys the colour and resets scale
                transform.GetChild(i).GetComponent<Image>().color = Color.grey;
                transform.GetChild(currentSlot).transform.localScale = Vector3.one * 1f;
            }
        }
        //selected slot brightened and larger
        transform.GetChild(currentSlot).GetComponent<Image>().color = Color.white;
        transform.GetChild(currentSlot).transform.localScale = Vector3.one * 1.1f;
    }
}
