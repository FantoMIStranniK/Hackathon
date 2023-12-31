using UnityEngine;

public class Teleporter : Interactable
{
    [SerializeField] private GameObject ObjectToTeleport;

    [SerializeField] private Transform TeleportPosition;

    public override void Use()
    {
        base.Use();
        ObjectToTeleport.transform.position = TeleportPosition.position;
    }
}
