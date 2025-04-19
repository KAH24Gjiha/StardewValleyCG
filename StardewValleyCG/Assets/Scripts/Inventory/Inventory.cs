using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 12;   //최대 슬롯

    private List<IInventoryItem>  mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;    //아이템 추가
    public event EventHandler<InventoryEventArgs> ItemRemoved;  //아이템 버리기
    public event EventHandler<InventoryEventArgs> ItemUsed;  //아이템 버리기

    public void AddItem(IInventoryItem item)
    {
        if(mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent< Collider2D>();
            if(collider.enabled)
            {
                collider.enabled = false;

                mItems.Add(item); //인벤토리 리스트에 추가

                item.OnPickup();    //아이템의 획득 처리 

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    internal void UseItem(IInventoryItem item)
    {
        if(ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (mItems.Contains(item))
        {
            mItems.Remove(item);

            item.OnDrop();

            Collider2D collider = (item as MonoBehaviour).GetComponent< Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}