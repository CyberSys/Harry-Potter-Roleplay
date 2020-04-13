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
    public bool learnable = false;
    public bool assigned = false;
    public int assignIndex;
    public GameObject assignPrompt;
    public Button assignPromptButton;
    public UnlockedSpells spellList;
    public AssignSpell assignSpell;
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

    private void Update()
    {
        if (learnButton != null)
        {
            if (learnable)
            {
                learnButton.interactable = true;
            }
            else if (learnt)
            {
                learnButton.interactable = false;
                learnable = false;
            }

        }

        //loop through player's unlocked spells
        for (int x = 0; x < spellList.unlockedSpells.Count; x++)
        {
            if(spell == spellList.unlockedSpells[x])
            {
                //enable learn button for this spell in the current spell slot index
                learnable = true;
                break;
            }
        }
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
        //show prompt to assign spell
        assignPrompt.SetActive(true);
        //wait for input
        //get number key pressed
        //assign spell to hotbar index of key pressed

    }



    //public method to learn spell
    public void LearnSpell(Spell spell)
    {
        spellList.learntSpells.Add(spell);
        Destroy(learnButton.gameObject);
        assignButton.interactable = true;
    }
}
