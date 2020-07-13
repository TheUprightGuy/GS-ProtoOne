using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setup Fields")]
    public bool AllowControlInAir = false;
    public float moveDeadZone = 0.15f;
    public float thrust = 1.0f;
    public float jumpThrust = 1.0f;
    public float VelocityLimit = 4.0f;

    // Player Control Tracking
    private bool keyDown = false;
    [HideInInspector] public float moveControlDelta = 0.0f;
    // Public for Animator
    [HideInInspector] public bool isBlocking = false;
    [HideInInspector] public bool isGrounded = true;
    public bool active;

    #region Setup
    [HideInInspector] public Rigidbody rb;
    private PlayerAnimation pa;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pa = GetComponent<PlayerAnimation>();
    }
    #endregion Setup

    // Update is called once per frame
    void Update()
    {
        VelocityLimit = isBlocking ? 1.4f : 4.0f;
    }

    private void FixedUpdate()
    {

        if ((isGrounded || AllowControlInAir) && 
            ((rb.velocity.x < VelocityLimit) && (rb.velocity.x > -VelocityLimit))) //Stops movement above Velocity limit
            {

                rb.AddForce(((-transform.right ) * (thrust * moveControlDelta)));
            }
    }

    public void OnDashForward()
    {
    }

    public void OnJump()
    {
        if (active)
        {
            if (isGrounded)
            {
                isBlocking = false;
                pa.Jump();

                Invoke("Jump", pa.jumpLength);
            }
        }
    }
    public void Jump()
    {
        rb.AddForce((transform.up) * jumpThrust, ForceMode.Impulse);
        isGrounded = false;
    }

    public void OnPunch()
    {
        if (active)
        {
        }
    }

    public void OnKick()
    {
        if (active)
        {
        }
    }

    public void OnCrouch()
    {
        if (active)
        {
        }
    }

    public void OnMove(InputValue value)
    {
        if (active)
        {
            float delta = value.Get<float>();
            moveControlDelta = (delta > moveDeadZone || delta < -moveDeadZone) ? (delta) : 0.0f;

            keyDown = !keyDown;

            if (!keyDown) //If released at all, stop movement
            {
                moveControlDelta = 0.0f;
            }
        }
    }

    public void OnBlock()
    {
        if (active)
        {
            if (isGrounded)
            {
                isBlocking = !isBlocking;
            }
        }
    }

    public void OnReadyUp()
    {
        //Replace with call to readyup function
        //UnityEngine.SceneManagement.SceneManager.LoadScene("JacobScene");
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
