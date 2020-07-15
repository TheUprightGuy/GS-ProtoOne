using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    public float HitCooldown = 0.1f;
    SphereCollider colliderComp;
    // Start is called before the first frame update
    void Start()
    {
        colliderComp = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    // }
    // private void OnTriggerEnter(Collider other) {
    //     if (other.transform.parent.tag == "Player")
    //     {
    //         colliderComp.enabled = false;
    //         Debug.Log("Hit");
    //         Invoke("HitCoolDown", HitCooldown);
    //     }
    //
    }


    public void HitSwitch()
    {
        colliderComp.enabled = !colliderComp.enabled;
    }
}
