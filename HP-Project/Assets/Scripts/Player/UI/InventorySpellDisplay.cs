using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySpellDisplay : MonoBehaviour
{
    public Spell spell;
    public Text spellName1;
    public Text spellName2;
    public Text spellDescription1;
    public Text spellDescription2;
    public Image icon;
    public Button learnButton;
    public Button assignButton;
    public SpellInteraction interactSpell;
    public bool learnt = false;
    public bool assigned = false;
    public int assignIndex;
    public GameObject assignPrompt;
    public Button assignPromptButton;
    public UnlockedSpells spellList;
    public AssignSpell assignSpell;

    private void Awake()
    {
        //find spell interaction script in parent
        interactSpell = GetComponentInParent<SpellInteraction>();
        //assign learn function to learn button when clicked
        learnButton.onClick.AddListener(() => Learn());
        //assign assign function to assign button when clicked
        assignButton.onClick.AddListener(() => AssignPopup());
        //assign primary text name display to spell name
        spellName1.text = spell.name;
        //assign primary text description display to spell name
        spellDescription1.text = spell.description;
        //assign secondary text name display to spell name
        spellName2.text = spell.name;
        //assign secondary text description display to spell name
        spellDescription2.text = spell.description;
        //assign spell slot sprite to spell's image
        icon.sprite = spell.image;
    }

    void Learn()
    {
        //inform the script that the current spell has been learnt
        learnt = true;
        //if the spell has been learnt
        if (learnt)
        {
            //learn the spell
            LearnSpell(spell);
        }
    }
    
    void AssignPopup()
    {
        //if the spell is not currently assigned
        if (!assigned)
        {
            //show prompt to assign spell
            assignPrompt.SetActive(true);
            //button pressed
            assignPromptButton.onClick.AddListener(() => assignSpell.SpellAssign(spell));
                //get number input to read index to assign spell to
                    //unassign any spell in slot
                    //assign spell to slot
                //update hotbar
            //close prompt
            assigned = true;
        }
    }



    //public method to learn spell
    public void LearnSpell(Spell spell)
    {
        spellList.learntSpells.Add(spell);
        assignButton.interactable = true;
    }
}
