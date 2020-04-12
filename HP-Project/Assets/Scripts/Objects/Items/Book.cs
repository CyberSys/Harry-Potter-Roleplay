using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Book", menuName = "Objects/Book")]
public class Book : Item
{
    public enum Type { Spell, Homework }
    public Type type;
    public Spell spell;

    public void Awake()
    {
        consumable = true;
    }

    public override void Use(GameObject player)
    {
        base.Use(player);
        if(type == Type.Spell)
        {
            Debug.Log("Used" + spell.name);
            var spellList = player.GetComponent<UnlockedSpells>();
            for (int i = 0; i < spellList.unlockedSpells.Count; i++)
            {
                if(spell != spellList.unlockedSpells[i])
                {
                    spellList.AddSpell(spell);
                    Debug.Log("Unlocked Spell " + spell);
                    break;
                } else
                {
                    Debug.Log("You already know this spell");
                }
            }
            //add to unlocked spell
        } else
        {
            Debug.Log("Gained Homework XP");
        }
    }
}
