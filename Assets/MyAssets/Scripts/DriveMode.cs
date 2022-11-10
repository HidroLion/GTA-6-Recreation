using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveMode : MonoBehaviour
{
    [Header("Car Scripts")]
    [SerializeField] GameObject cameraCar;
    [SerializeField] Transform playerHide;
    [SerializeField] Transform playerPos;

    [Header("Player Scripts")]
    [SerializeField] Transform playerTrans;
    [SerializeField] GameObject cameraManager;
    [SerializeField] GameObject cameraPlayer;
    [SerializeField] PlayerControl playerControl;
    [SerializeField] CameraControl cameraControl;

    CarMovement carMovement;

    bool driverMode, playerNearvy;

    private void Awake()
    {
        cameraCar.SetActive(false);

        carMovement = GetComponent<CarMovement>();
        carMovement.enabled = false;
        driverMode = false;
        playerNearvy = false;
    }

    private void Update()
    {
        if (playerNearvy && !driverMode)
        {
            if (Input.GetKeyDown(KeyCode.F) && !driverMode)
            {
                Drive();
                Debug.Log("Driving");
            }
        }
        if (driverMode && !playerNearvy)
        {
            playerTrans.position = playerHide.position;
            if (Input.GetKeyDown(KeyCode.F))
            {
                Undrive();
                Debug.Log("Undriving");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearvy = true;
            Debug.Log("Player Detected");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearvy = false;
            Debug.Log("Player Not Detected");
        }
    }

    void Drive()
    {
        playerTrans.position = playerHide.position;
        playerControl.enabled = false;
        cameraControl.enabled = false;

        cameraManager.SetActive(false);
        cameraPlayer.SetActive(false);
        cameraCar.SetActive(true);

        carMovement.enabled = true;
        carMovement.driveMode = true;
        driverMode = true;
    }

    void Undrive()
    {
        cameraCar.SetActive(false);

        carMovement.enabled = false;
        carMovement.driveMode = false;
        driverMode = false;

        playerControl.enabled = true;

        playerTrans.position = playerPos.position;
        cameraManager.SetActive(true);
        cameraPlayer.SetActive(true);
        driverMode = false;
    }
}
