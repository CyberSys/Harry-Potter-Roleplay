using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInteraction : MonoBehaviour
{
    public UnlockedSpells spellList;
    public List<Button> learnButtons;
    private Spell currentSpell;

    public void Awake()
    {
        //Debug.Log(transform.childCount);
    }

    //learnButtons[i].onClick.AddListener(() => LearnSpell(spellDisplay.spell));
    //learnButtons[x].interactable = true;
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var currentChild = transform.GetChild(i);
            var spellObject = currentChild.GetComponent<InventorySpellDisplay>();
            if (spellObject != null)
            {
                var spell = spellObject.spell;
                if (spellObject.isActiveAndEnabled)
                {
                    for (int x = 0; x < spellList.unlockedSpells.Count; x++)
                    {
                        for (int j = 0; j < spellList.learntSpells.Count; j++)
                        {
                            if (spell == spellList.unlockedSpells[x] && spell != spellList.learntSpells[j])
                            {
                                //Debug.Log("Spell unlocked: " + spell.name);
                                currentSpell = spell;
                                learnButtons[i].interactable = true;
                            } else if (spell == spellList.unlockedSpells[x] && spell == spellList.learntSpells[j])
                            {
                                learnButtons[i].interactable = false;
                                currentSpell = spell;
                                //Debug.Log(spell.name);
                            } else
                            {
                                learnButtons[i].interactable = false;
                            }
                        }
                    }
                }
            }
        }
    }

    public void LearnSpell(Spell spell)
    {
        spellList.learntSpells.Add(spell);
    }

}
