using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivty = 2f;
    float cameraVerticalRotation = 0f;

    //bool lockedCursor = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivty;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivty;

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

        player.Rotate(Vector3.up * inputX);
        
    }
}
