using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHendler : MonoBehaviour
{
    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.item;

        Debug.LogError("ItemImage ������Ʈ�� ã�� �� �����ϴ�."); 
        
        item.OnUse();
    }
}
