using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstThirdTrans : MonoBehaviour
{
    [SerializeField] GameObject freeLookCamera;
    [SerializeField] public GameObject fpsPlayer;
    [SerializeField] GameObject cameraPlayer;
    [SerializeField] GameObject playerModel;
    [SerializeField] public Transform cameraFpsPos;

    PlayerControl playerControl;
    bool fpsMode;

    public bool FpsMode { get => fpsMode; set => fpsMode = value; }

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
            FpsMode = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            playerControl.enabled = true;
            fpsPlayer.SetActive(false);
            playerModel.SetActive(true);
            cameraPlayer.SetActive(true);
            freeLookCamera.SetActive(true);

            FpsMode = false;
        }
    }
}
