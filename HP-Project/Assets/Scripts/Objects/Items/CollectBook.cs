using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBook : Interactable
{
    public Book book;

    public override void InteractedWith()
    {
        base.InteractedWith();
        Pickup();
    }

    public void Pickup()
    {
        Debug.Log("PICKING UP " + book.name);
        bool wasPickedUp = InventoryManager.instance.AddItem(book);
        if (wasPickedUp)
        {
            if (book.consumable)
            {
                Destroy(gameObject);
            }
        }
    }

}
