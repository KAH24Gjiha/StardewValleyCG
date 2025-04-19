using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHendler : MonoBehaviour
{
    public void OnItemClicked()
    {
        ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.item;

        Debug.LogError("ItemImage 오브젝트를 찾을 수 없습니다."); 
        
        item.OnUse();
    }
}
