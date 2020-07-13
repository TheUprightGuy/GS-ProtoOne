using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Setup
    private Animator animator;
    private Rigidbody rb;
    private BoxCollider myCollider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider>();
        distToGround = myCollider.bounds.extents.y;
    }
    #endregion Setup

    public bool grounded = false;
    public float speed;
    public float distToGround;
    public bool blocking = false;

    public void Update()
    {
        animator.SetBool("Grounded", grounded);

        var localVelocity = Quaternion.Inverse(transform.rotation) * (rb.velocity / speed);
        animator.SetFloat("PosX", localVelocity.x);
        animator.SetFloat("PosY", localVelocity.z);

        AnimationState();
    }

    public void FixedUpdate()
    {
        // CHECK IF GROUNDED - SET BOOL
        grounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);

        // EXAMPLE CODE - REPLACE
        // var inputRun = Vector3.ClampMagnitude(new Vector3(Input.Runx, 0, Input.RunZ), 1);
        // var inputLook = Vector3.ClampMagnitude(new Vector3(Input.LookX, 0, Input.LookZ), 1);
        // rb.velocity = new Vector3(inputRun.x * speed, rb.velocity.y, inputRun.z * speed);
    }

    public void AnimationState()
    {
        animator.SetBool("isBlocking", blocking);
        /*if (jumping)
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
            animator.SetTrigger("Hit");
        }
        if (dashforward)
        {
            animator.SetTrigger("DashForward");
        }
        if (dashbackward)
        {
            animator.SetTrigger("DashBack");
        }*/
    }
}
