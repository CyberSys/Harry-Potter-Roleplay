using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInteraction : MonoBehaviour
{
    public UnlockedSpells spellList;
    public List<Button> learnButtons;
    private Spell currentSpell;
    
    private void Update()
    {

        //loop through each spell slot
        for (int i = 0; i < transform.childCount; i++)
        {
            //assign the current child
            var currentChild = transform.GetChild(i);
            //take the spell display script from the current child
            var spellObject = currentChild.GetComponent<InventorySpellDisplay>();
            //if there is a spell no the child
            if (spellObject != null)
            {
                //read the spell item from the spell display script
                var spell = spellObject.spell;
                //check if spell display script is enaled
                if (spellObject.isActiveAndEnabled)
                {
                    //loop through player's unlocked spells
                    for (int x = 0; x < spellList.unlockedSpells.Count; x++)
                    {
                        //loop through player's learnt spells
                        for (int j = 0; j < spellList.learntSpells.Count; j++)
                        {
                            //check if spell is in unlocked spells and not learnt spells
                            if (spell == spellList.unlockedSpells[x] && spell != spellList.learntSpells[j])
                            {
                                //assign current spell to this spell
                                currentSpell = spell;
                                //enable learn button for this spell in the current spell slot index
                                learnButtons[i].interactable = true;
                            } else
                            {
                                //otherwise disable learn button in current spell slot index
                                learnButtons[i].interactable = false;
                            }
                        }
                    }
                }
            }
        }
    }

}
