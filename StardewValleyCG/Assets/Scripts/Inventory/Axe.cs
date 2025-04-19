using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour, IInventoryItem    //���� ������
{
    public string Name
    {
        get
        {
            return "Axe";
        }
    }

    public Sprite _Image = null;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public void OnDrop()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
        if (hit.collider != null)
        {
            gameObject.SetActive(true);
            // �� ��ġ�� ������Ʈ �ű��
            gameObject.transform.position = new Vector3(hit.point.x, hit.point.y, 0f);
        }
    }

    public void OnUse()
    {
        throw new System.NotImplementedException();
    }
}
