using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private float moveControlDelta = 0.0f;
    PlayerControls inputs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
   
    public void OnJump()
    {
    }
    public void OnCrouch()
    {
    }

    public void OnMove(InputValue value)
    {
        moveControlDelta = value.Get<float>();
    }

    public void DebugName()
    {
        Debug.Log(gameObject.name);
    }
}
