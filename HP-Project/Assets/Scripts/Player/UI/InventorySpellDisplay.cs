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
    public SpellInteraction interactSpell;

    private void Awake()
    {
        interactSpell = GetComponentInParent<SpellInteraction>();
        learnButton.onClick.AddListener(() => interactSpell.LearnSpell(spell));
        spellName1.text = spell.name;
        spellDescription1.text = spell.description;
        spellName2.text = spell.name;
        spellDescription2.text = spell.description;
        icon.sprite = spell.image;
    }


}
