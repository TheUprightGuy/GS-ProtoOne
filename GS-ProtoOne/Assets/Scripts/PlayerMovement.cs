using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    Vector2 delta = Vector2.zero;
    PlayerControls inputs;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(delta.x, delta.y, 0.0f);
        delta = Vector2.zero;
    }
    
   
    public void OnUp(InputValue value)
    {
        delta.y = 0.1f;
        //DebugName();
    }
    public void OnDown()
    {
        delta.y = -0.1f;
        //DebugName();
    }

    public void OnLeft()
    {
        delta.x = -0.1f;
        //DebugName();
    }
    public void OnRight()
    {
        delta.x = 0.1f;
        //DebugName();
    }

    public void DebugName()
    {
        Debug.Log(gameObject.name);
    }
}
