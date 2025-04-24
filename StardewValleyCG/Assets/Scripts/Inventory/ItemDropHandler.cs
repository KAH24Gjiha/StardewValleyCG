using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        // ���� ���콺 ��ġ�� �� �г� �ٱ����� Ȯ��
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Drop item");
        }

        Transform imageTransform = gameObject.transform.Find("ItemImage");

        if (imageTransform == null)
        {
            Debug.LogWarning("ItemImage ������Ʈ�� ã�� �� �����ϴ�.");
            return;
        }

        ItemDragHandler dragHandler = imageTransform.GetComponent<ItemDragHandler>();

        if (dragHandler == null)
        {
            Debug.LogWarning("ItemDragHandler ������Ʈ�� �����ϴ�.");
            return;
        }

    }
}
