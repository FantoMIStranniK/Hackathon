using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform MainCamera;

    [SerializeField] private LayerMask InteractableLayer;

    private Interactable lastInteractable = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyBinds.UseKey))
            TryInteract();
    }
    private void TryInteract()
    {
        RaycastHit interactRay;

        if (Physics.Raycast(MainCamera.position, MainCamera.forward, out interactRay, 1.5f, InteractableLayer))
        {
            var hittedGameobject = interactRay.collider.gameObject;

            var useable = hittedGameobject.GetComponent<Interactable>();

            if(lastInteractable == null && useable != null)
            {
                useable.Use();
                lastInteractable = useable;
            }
            else if (lastInteractable != null && useable != null)
            {
                useable.StopUsing();
                lastInteractable = null;
            }
        }
    }
}