using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float HitCooldown = 0.5f;
    private GameObject hitCollider = null;
    
  

    
private void OnCollisionEnter(Collision other) {
      if (other.gameObject.tag == "Hit")
        {
            Debug.Log("Hit");
            GetComponent<BoxCollider>().enabled = false;
            Invoke("HitboxHit", HitCooldown);

        }
}
 
}
