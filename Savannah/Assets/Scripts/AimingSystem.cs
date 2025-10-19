using UnityEngine;

public class AimingSystem : MonoBehaviour
{

    public Camera cam;
    // Update is called once per frame
    void Update()
    {
        // 0 left click 1 right click 2 middle button
        if(Input.GetMouseButton(1))
        {
            cam.fieldOfView = 40;
        }
        else
        {
            cam.fieldOfView = 60;
        }
    }
}
