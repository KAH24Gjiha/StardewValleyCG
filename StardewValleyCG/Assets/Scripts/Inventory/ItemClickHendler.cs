using JetBrains.Annotations;
using UnityEngine;
using System;

public class ItemClickHendler : MonoBehaviour
{
    public Inventory _Inventory;
    private InteractableItemBase AttachedItem
    {
        get
        {
            ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

            return (InteractableItemBase)dragHandler.item;
        }
    }

    public void OnItemClicked()
    {
        InteractableItemBase item = AttachedItem;

        if (item != null)
        {
            _Inventory.UseItem((IInventoryItem)item);
        }
    }

}
