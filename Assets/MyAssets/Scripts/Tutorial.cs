using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorialObject;
    bool activate;

    private void Start()
    {
        activate = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            tutorialObject.SetActive(!activate);
            activate = !activate;
        }
    }
}
