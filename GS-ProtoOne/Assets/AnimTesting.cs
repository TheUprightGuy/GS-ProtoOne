using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTesting : MonoBehaviour
{
    #region Setup
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    #endregion Setup

    public bool blocking = false;
    public bool walking = false;
    public bool jumping = false;
    public bool punching = false;
    public bool kicking = false;
    public bool flinching = false;
    public bool dashforward = false;
    public bool dashbackward = false;

    public void Update()
    {
        AnimationState();
    }

    public void AnimationState()
    {
        animator.SetBool("isBlocking", blocking);
        animator.SetBool("isWalking", walking);
        if (jumping)
        {
            animator.SetTrigger("Jumping");
        }
        if (punching)
        {
            animator.SetTrigger("Punching");
        }
        if (kicking)
        {
            animator.SetTrigger("Kicking");
        }
        if (flinching)
        {
            animator.SetTrigger("Flinching");
        }
        if (dashforward)
        {
            animator.SetTrigger("DashForward");
        }
        if (dashbackward)
        {
            animator.SetTrigger("DashBack");
        }
    }
}
