using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory");
            return;
        }
        instance = this;
    }
    #endregion

    public PlayerManager playerManager;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public List<Spell> hotbarSpells;

    [SerializeField]
    private DisplayWarning displayText;

    public int space = 24;
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        //item space check
        if (items.Count >= space)
        {
            Debug.Log("Inventory Full");
            return false;
        }
        //year level check
        else if (item.requiredYear >= playerManager.playerYear && item.requiredYear != 0)
        {
            Debug.Log("This year cannot have this item");
            return false;
        }
        //house check
        else if (item.requiresHouse && item.requiredHouse.ToString() != playerManager.playerHouse.ToString())
        {
            Debug.Log("This house cannot have this item");
            return false;
        }

        //item in inventory check
        for (int i = 0; i < items.Count; i++)
        {
            if (item == items[i])
            {
                displayText.DisplayText("You already have " + item.name, 2f);
                Debug.Log("You already have " + item.name);
                return false;
            }
        }
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        //Instantiate(item.prefab, this.transform);
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

}
