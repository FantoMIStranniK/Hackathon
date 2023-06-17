using UnityEngine;

public enum ItemType
{ 
    Key,
    Crystal,
}
public class Item : Interactable
{
    public string ItemName;

    public ItemType Type;

    public override void Use()
        => PickUp();
    private void PickUp()
    {
        Inventory.AddItem(this);

        Destroy(gameObject);
    }
}
