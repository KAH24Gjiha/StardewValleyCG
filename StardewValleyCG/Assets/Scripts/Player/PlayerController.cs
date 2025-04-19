using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Inventory inventory;

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
