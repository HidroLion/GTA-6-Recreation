using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AimNPC : MonoBehaviour
{
    [SerializeField] Transform cameraDirection;
    [SerializeField] float aimRange;
    [SerializeField] TMPro.TMP_Text moneyText;
    [SerializeField] float moneyGain;

    FirstThirdTrans player;
    RaycastHit hit;
    tauntNPC taunt;
    float moneyCount;
    bool moneyGet;
    float timer;

    private void Awake()
    {
        player = GetComponent<FirstThirdTrans>();
        moneyCount = 0;
        UpdateText();
        moneyGet = false;
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
                    if(!moneyGet)
                        GetMoney();
                    taunt.Scare();
                }
            }
        }

        if (moneyGet)
        {
            timer += Time.deltaTime;
            if(timer >= 20)
            {
                timer = 0;
                moneyGet = false;
            }
        }
    }

    void GetMoney()
    {
        moneyCount += moneyGain;
        moneyGet = true;
        UpdateText();
    }

    void UpdateText()
    {
        moneyText.text = moneyCount.ToString("C2");
    }
}
