using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        // 현재 마우스 위치가 이 패널 바깥인지 확인
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            Debug.Log("Drop item");
        }

        Transform imageTransform = gameObject.transform.Find("ItemImage");

        if (imageTransform == null)
        {
            Debug.LogWarning("ItemImage 오브젝트를 찾을 수 없습니다.");
            return;
        }

        ItemDragHandler dragHandler = imageTransform.GetComponent<ItemDragHandler>();

        if (dragHandler == null)
        {
            Debug.LogWarning("ItemDragHandler 컴포넌트가 없습니다.");
            return;
        }

    }
}
