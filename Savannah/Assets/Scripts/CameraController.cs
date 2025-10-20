using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivty = 2f;
    float cameraVerticalRotation = 0f;
    public static float rotationSpeed = 20.0f;
    public static bool cameraUnlocked = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraUnlocked)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivty;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivty;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            player.Rotate(Vector3.up * inputX);
        }

    }

    public static void LockCamera()
    {
        cameraUnlocked = false;
    }

    public static void LookAtTarget(GameObject obj, Transform tfm)
    {
        Vector3 targetPos = obj.transform.position + new Vector3(0f, .9f, 0f);
        Vector3 targetDirection = targetPos - tfm.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(tfm.forward, targetDirection, singleStep, 0.0f);
        tfm.rotation = Quaternion.LookRotation(newDirection);
    }
}
