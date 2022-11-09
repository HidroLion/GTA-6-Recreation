using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Vector2 sensibilityMouse;
    [SerializeField] Transform cam;

    float x, y;
    float angle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        if(x != 0 )
        {
            transform.Rotate(Vector3.up * x * sensibilityMouse.x);
        }

        if(y != 0)
        {
            angle = (cam.localEulerAngles.x - y * sensibilityMouse.y + 360) % 360;

            if (angle > 180)
            {
                angle -= 360;
            }
            angle = Mathf.Clamp(angle, -20, 80);

            cam.localEulerAngles = angle * Vector3.right;
        }
    }
}
