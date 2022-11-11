using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimNPC : MonoBehaviour
{
    [SerializeField] Transform cameraDirection;
    [SerializeField] float aimRange;

    FirstThirdTrans player;
    RaycastHit hit;
    tauntNPC taunt;

    private void Awake()
    {
        player = GetComponent<FirstThirdTrans>();
    }

    private void Update()
    {
        if (player.FpsMode)
        {
            Physics.Raycast(cameraDirection.position, cameraDirection.forward, out hit);

            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    taunt = hit.collider.GetComponent<tauntNPC>();
                    taunt.Scare();
                }
            }
        }
    }
}
