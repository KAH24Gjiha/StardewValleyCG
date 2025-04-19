using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Inventory : MonoBehaviour
{
    //아이템을 인벤토리에 추가했을 때, UI 상의 빈 슬롯을 찾아 아이템 이미지를 표시하는 기능
    
    public Inventory Inventory;  // 연결할 Inventory 클래스

    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        foreach (Transform slot in inventoryPanel)
        {
            // slot 안 오브젝트 선택
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();
            
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.item = e.Item;
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            if (itemDragHandler.item.Equals(e.Item))
            {
                image.enabled =false;
                image.sprite = null;
                itemDragHandler.item = null;
                break;
            }
        }
    }
}
