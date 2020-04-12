using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public bool consumable;

    public new string name;
    public string description;
    
    public int requiredYear;
    public enum RequiredHouse { Gryffindor, Ravenclaw, Hufflepuff, Slytherin };
    public RequiredHouse requiredHouse;
    public bool requiresHouse;

    public virtual void Use(GameObject player)
    {
        Debug.Log("Item Used: " + name);
    }

}
