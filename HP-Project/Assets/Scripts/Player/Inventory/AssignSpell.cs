using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSpell : MonoBehaviour
{
    public InventoryManager inventory;

    public void SpellAssign(Spell spell)
    {
        //grab number input
        int index = 5;
        inventory.hotbarSpells[index] = spell;
    }
}
