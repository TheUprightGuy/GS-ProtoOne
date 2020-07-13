using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool AllowControlInAir = false;
    public float moveDeadZone = 0.15f;
    public float thrust = 1.0f;
    public float jumpThrust = 1.0f;
    public bool jumping = false;

    public float VelocityLimit = 5.0f;
    public bool isGrounded = true;

    private float moveControlDelta = 0.0f;
    private Rigidbody rb;
    private Animator animator;
    private float jumpLength;
    public bool isBlocking = false;
    private bool keyDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        foreach (AnimationClip ac in animator.runtimeAnimatorController.animationClips)
        {
            if (ac.name == "JumpStart")
            {
                jumpLength = ac.length;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("isBlocking", isBlocking);
    }

    private void FixedUpdate()
    {

        if ((isGrounded || AllowControlInAir) && 
            ((rb.velocity.x < VelocityLimit) && (rb.velocity.x > -VelocityLimit))) //Stops movement above Velocity limit
        {

            rb.AddForce(((transform.forward ) * (thrust * moveControlDelta)));
        }
    }

    public void OnJump()
    {
        if (isGrounded)
        {
            jumping = true;
            animator.SetTrigger("Jumping");

            Invoke("Jump", jumpLength);
        }
    }

    public void OnPunch()
    {
        animator.SetTrigger("Punching");
    }

    public void OnKick()
    {
        animator.SetTrigger("Kicking");
    }

    public void Jump()
    {
        rb.AddForce((transform.up) * jumpThrust, ForceMode.Impulse);
        isGrounded = false;
    }

    public void OnCrouch()
    {
    }

    public void OnMove(InputValue value)
    {
        float delta = value.Get<float>();
        moveControlDelta = (delta > moveDeadZone || delta < -moveDeadZone) ? (delta) : 0.0f;

        keyDown = !keyDown;

        if (!keyDown) //If released at all, stop movement
        {
            moveControlDelta = 0.0f;
        }
    }

    public void OnBlock()
    {
        isBlocking = !isBlocking;
    }

    public void OnReadyUp()
    {
        //Replace with call to readyup function
        UnityEngine.SceneManagement.SceneManager.LoadScene("JacobScene");
    }

    public void DebugName()
    {
        Debug.Log(gameObject.name);
    }

    private void OnGUI()
    {
        //Vector3 moveVec = (transform.forward) * (thrust * moveControlDelta);
        //GUI.Box(new Rect(10, 10, 100, 50), rb.velocity.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If touching a collider marked as ground, jump will be enabled
        isGrounded = (collision.gameObject.tag == "Ground");
    }
}
