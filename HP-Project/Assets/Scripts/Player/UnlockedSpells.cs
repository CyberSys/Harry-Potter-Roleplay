using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedSpells : MonoBehaviour
{
    public List<Spell> unlockedSpells;
    public List<Spell> learntSpells;

    public void AddSpell(Spell spell)
    {
        bool canAdd = false;
        for (int i = 0; i < unlockedSpells.Count; i++)
        {
            if (spell != unlockedSpells[i])
            {
                canAdd = true;
            } else
            {
                canAdd = false;
            }
        }
        if (canAdd)
        {
            unlockedSpells.Add(spell);
        }
    }
}
