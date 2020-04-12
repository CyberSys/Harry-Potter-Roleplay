using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : Interactable
{
    public Item item;

    public override void InteractedWith()
    {
        base.InteractedWith();
        Pickup();
    }

    public void Pickup()
    {
        Debug.Log("PICKING UP " + item.name);
        bool wasPickedUp = InventoryManager.instance.AddItem(item);
        if (wasPickedUp)
        {
            if (item.consumable)
            {
                Destroy(gameObject);
            }
        }
    }

}
