using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] float mouseSensibility;
    float x, y;
    Vector3 move;
    Vector3 angle;

    public Vector2 MouseVector()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        move = new Vector2(x, y);

        return move;
    }

    private void Update()
    {
        MouseMove();
    }

    void MouseMove()
    {
        transform.Rotate(Vector3.up * MouseVector().x * mouseSensibility * Time.deltaTime);
    }
}
