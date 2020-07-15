using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    #region Setup
    private Animator animator;
    private PlayerMovement pm;
    [HideInInspector] public float jumpLength;
    public bool active = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        
        foreach (AnimationClip ac in animator.runtimeAnimatorController.animationClips)
        {
            if (ac.name == "JumpStart")
            {
                jumpLength = ac.length;
            }
        }
    }
#endregion Setup

    // Update is called once per frame
    void Update()
    {
        // Update Anim States
        animator.SetBool("Grounded", pm.isGrounded);
        animator.SetBool("isBlocking", pm.isBlocking);
        animator.SetFloat("PosX", -pm.velocity / pm.VelocityLimit);
    }


    public void Hit()
    {
        if (active)
        {
            animator.SetTrigger("Hit");
        }
    }

    public void Jump()
    {
        if (active)
        {
            animator.SetTrigger("Jumping");
        }
    }

    public void OnPunch()
    {
        if (active)
        {
            animator.SetTrigger("Punching");
        }
    }

    public void OnKick()
    {
        if (active)
        {
            animator.SetTrigger("Kicking");
        }
    }
}
