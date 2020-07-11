using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Setup
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    #endregion Setup

    public bool blocking = false;

    public void Update()
    {
        AnimationState();
    }

    public void AnimationState()
    {
        animator.SetBool("isBlocking", blocking);
    }
}
