using UnityEngine;
public class PlayerControllerRunner : MonoBehaviour
{
    public float mouseSensitivty = 2f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivty;
        Debug.Log(inputX);
        this.transform.Rotate(Vector3.up * inputX);
    }
}
