using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : InteractableItemBase
{
    public override string Name
    {
        get { return "Axe"; }
    }

    public override void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public override void OnDrop()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
        if (hit.collider != null)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = new Vector3(hit.point.x, hit.point.y, 0f);
        }
    }

    public override void OnUse()
    {
        base.OnUse();
    }
}
