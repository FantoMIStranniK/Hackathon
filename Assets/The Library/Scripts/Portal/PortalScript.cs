using UnityEngine;

public class PortalScript : Interactable
{
    [SerializeField] private CanvasGroup WinScreen;

    private bool used = false;

    public override void Use()
    {
        base.Use();

        if (!HasAllRunes())
            return;

        if (used)
            return;

        used = true;
    }
    private void Update()
    {
         if(used)
            WinScreen.alpha += Time.deltaTime;
    }
    private bool HasAllRunes()
        => Inventory.ContainsItem("Rune1", ItemType.Key) && Inventory.ContainsItem("Rune2", ItemType.Key) && Inventory.ContainsItem("Rune3", ItemType.Key);
}
