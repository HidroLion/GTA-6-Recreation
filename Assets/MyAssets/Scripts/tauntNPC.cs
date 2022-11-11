using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tauntNPC : MonoBehaviour
{
    bool danger;
    float timer;

    [SerializeField] Animator animator;
    [SerializeField] float scaryTime;

    private void Awake()
    {
        danger = false;
    }

    public void Scare()
    {
        if (!danger)
        {
            Debug.Log("Enemy Scare");
            danger = true;
            animator.SetBool("Aimed", true);
        }
    }

    private void Update()
    {
        if (danger)
        {
            timer += Time.deltaTime;
            if(timer >= scaryTime)
            {
                danger = false;
                Debug.Log("Calm Down");
                animator.SetBool("Aimed", false);
                timer = 0;
            }
        }
    }
}
