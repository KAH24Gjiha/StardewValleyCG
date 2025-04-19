using UnityEngine;

public class InteractableItemBase : MonoBehaviour
{
    public virtual string Name => "_vase item_";

    [SerializeField]
    protected Sprite _Image;

    public string InteractText = "Press F to pickup the item";

    public virtual Sprite Image => _Image;

    public virtual void OnDrop()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            transform.position = hit.point;
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnUse() { }
}
