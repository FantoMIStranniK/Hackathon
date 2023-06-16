using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] private float modifier;

    [SerializeField] private Transform PlayerParent;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * modifier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * modifier;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        PlayerParent.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
