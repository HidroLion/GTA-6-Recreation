using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThirdTrans : MonoBehaviour
{
    [SerializeField] Transform fpsCamPos;
    [SerializeField] Transform cameraPos;
    [SerializeField] GameObject freeLookCamera;
    CameraControl cameraControl;
    bool fpsMode;

    private void Awake()
    {
        fpsMode = false;
        cameraControl = GetComponent<CameraControl>();
        cameraControl.enabled = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            freeLookCamera.SetActive(false);
            cameraPos.position = fpsCamPos.position;
            cameraPos.rotation = fpsCamPos.rotation;

            cameraControl.enabled = true;

            fpsMode = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            cameraControl.enabled = false;
            freeLookCamera.SetActive(true);

            fpsMode = false;
        }
    }
}
