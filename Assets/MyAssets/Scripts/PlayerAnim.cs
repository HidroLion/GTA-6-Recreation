using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] Animator anim;
    Rigidbody rb;
    bool sneak;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Run(bool state)
    {
        anim.SetBool("Running", state);
    }

    public void SneakRun(bool state)
    {
        anim.SetBool("SRunning", state);
    }

    public void CrouchStand(bool state)
    {
        anim.SetBool("Crouch", state);
        sneak = state;
    }
}
