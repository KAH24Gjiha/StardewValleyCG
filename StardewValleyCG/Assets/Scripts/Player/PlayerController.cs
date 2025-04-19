using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Inventory inventory;

    public GameObject Hand;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem = (item as MonoBehaviour).gameObject;
        goItem.SetActive(true);

        goItem.transform.parent = Hand.transform;
        goItem.transform.position = Hand.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어가 아이템과 접촉했을 때, 자동으로 인벤토리에 들어간다.
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }

}
