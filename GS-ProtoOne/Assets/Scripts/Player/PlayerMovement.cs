using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Setup Fields")]
    public bool AllowControlInAir = false;
    public float moveDeadZone = 0.15f;
    public float thrustInAir = 1.0f;
    public float moveSpeed = 0.1f;
    public float jumpThrust = 1.0f;
    public float VelocityLimit = 4.0f;

    private float lastPosX = 0.0f;
    public float velocity;


    public float girth = 1.0f;
    // Player Control Tracking
    private bool keyDown = false;
    [HideInInspector] public float moveControlDelta = 0.0f;
    // Public for Animator
    [HideInInspector] public bool isBlocking = false;
    [HideInInspector] public bool isGrounded = true;
    public bool active;

    [Header("AbilityFields")]
    public bool charging = false;
    public float chargingTimer = 0.0f;

    #region Setup
    [HideInInspector] public Rigidbody rb;
    private PlayerAnimation pa;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pa = GetComponent<PlayerAnimation>();
        lastPosX = transform.position.x;

    }
    #endregion Setup

    // Update is called once per frame
    void Update()
    {
        

        VelocityLimit = isBlocking ? 1.4f : 4.0f;
        chargingTimer -= Time.deltaTime;
        if (chargingTimer <= 0)
        {
            charging = false;
        }
    }


    private void FixedUpdate()
    {
        Vector3 closestPlayerPos = transform.position;
        float closestDist = 1000.0f;
        foreach (var item in GameObject.FindGameObjectsWithTag("Player"))
        {
            float dist = Vector3.Distance(transform.position, item.transform.position);

            if (dist < closestDist && transform.position != item.transform.position)
            {
                closestDist = dist;
                closestPlayerPos = item.transform.position;
            }
        }

        Vector3 temp = transform.localScale;
        if (closestPlayerPos.x > transform.position.x)
        {
            temp.z = -1;

            if (moveControlDelta < 0 && closestDist < girth)
            {
                moveControlDelta = 0;
            }
        }
        else
        {
            if (moveControlDelta > 0 && closestDist < girth)
            {
                moveControlDelta = 0;
            }
            temp.z = 1;
        }
        transform.localScale = temp;


        if (((rb.velocity.x < VelocityLimit) && (rb.velocity.x > -VelocityLimit))) //Stops movement above Velocity limit
        {
            if (isGrounded)
            {
                rb.MovePosition(transform.position +
                    ((-Vector3.right) * (moveSpeed * moveControlDelta)));
            }
            else
            {
                rb.AddForce(((-Vector3.right ) * (thrustInAir * moveControlDelta)));
            }

        }

        velocity = ((transform.position.x - lastPosX) / Time.timeScale) * 1000.0f;
        velocity *= transform.localScale.x;
        lastPosX = transform.position.x;
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
            //if (charging == false)
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
        //GUI.Box(new Rect(10, 10, 100, 50), Time.fixedTime.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If touching a collider marked as ground, jump will be enabled
        isGrounded = (collision.gameObject.tag == "Ground");


    }
}
