using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSpell : MonoBehaviour
{
    public InventoryManager inventory;
    bool waitForInput = true;
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

    public void SpellAssign(Spell spell)
    {
        //grab number input
        //int index = 5;
        while (waitForInput == true)
        {
            //inventory.hotbarSpells[i] = spell;
            waitForInput = false;
        }
    }
}
