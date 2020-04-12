using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public GameObject dropButton;
    public GameObject player;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.image;
        icon.enabled = true;
        dropButton.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        dropButton.SetActive(false);
    }

    public void OnRemoveButton()
    {
        InventoryManager.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use(player);
            if(item.consumable)
            {
                InventoryManager.instance.RemoveItem(item);
            }
        }
    }

}
