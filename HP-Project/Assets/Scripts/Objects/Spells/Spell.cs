using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Objects/Spell")]
public class Spell : ScriptableObject
{

    public enum SpellType { Transfiguration, Charm, Jinx, Hex, Curse, CounterSpell, Healing }
    public enum SpellCategory { Damage, Healing, Effect, Other }
    public enum CastType { Shoot, Wand, SelfCast }

    [Header("Media")]
    public Sprite image;
    public GameObject spellPrefab;

    [Header("Attributes")]
    public new string name;
    [TextArea]
    public string description;
    public SpellType spellType;
    public SpellCategory spellCategory;
    public CastType castType;
    public bool dieOnCollision;
    public int time;
    public GameObject destroyPrefab;

    public float force;

    [Header("Requirements")]
    public int requiredYear;

    public virtual void Cast()
    {
        Debug.Log("Item Used: " + name);
    }

}
