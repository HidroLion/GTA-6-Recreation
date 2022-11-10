using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] Vector2 speed;

    Transform cameraPos;
    float x, rotate;
    public bool driveMode;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        driveMode = false;
    }

    private void Update()
    {
        if (driveMode)
            CarControl();
    }

    void CarControl()
    {
        x = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        transform.position += transform.forward * speed.x * Time.deltaTime * x;

        if (x != 0)
        {
            transform.Rotate(Vector3.up * rotate * speed.y * Time.deltaTime);
        }
    }
}
