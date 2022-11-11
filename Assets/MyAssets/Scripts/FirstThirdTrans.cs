using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThirdTrans : MonoBehaviour
{
    [SerializeField] GameObject freeLookCamera;
    [SerializeField] GameObject fpsPlayer;
    [SerializeField] GameObject cameraPlayer;
    [SerializeField] GameObject playerModel;
    [SerializeField] Transform cameraFpsPos;

    PlayerControl playerControl;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerControl = GetComponent<PlayerControl>();
        fpsPlayer.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            playerControl.enabled = false;
            cameraPlayer.SetActive(false);
            freeLookCamera.SetActive(false);
            playerModel.SetActive(false);
            fpsPlayer.SetActive(true);

            fpsPlayer.transform.position = cameraFpsPos.position;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            playerControl.enabled = true;
            fpsPlayer.SetActive(false);
            playerModel.SetActive(true);
            cameraPlayer.SetActive(true);
            freeLookCamera.SetActive(true);
        }
    }
}
