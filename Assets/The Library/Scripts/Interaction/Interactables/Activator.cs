using UnityEngine;

public class Activator : Interactable
{
    [SerializeField] private string RequiredItemName;
    [SerializeField] private ItemType RequiredItemType;

    [SerializeField] private Activatable MyActivateable;

    [SerializeField] private bool ActivateOnce;

    private bool activated = false;

    public override void Use()
    {
        if (!Inventory.ContainsItem(RequiredItemName, RequiredItemType))
            return;

        if (activated && ActivateOnce)
            return;

        base.Use();

        MyActivateable.Activate();

        activated = true;
    }
}
