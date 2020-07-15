using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float BlockPercent = 0.5f;
    private GameObject hitCollider = null;

    public Vector3 hitPos = Vector3.zero;

    public float blockTopY = 0.0f;
    public float blockBottomY = 1.0f;

    [Header("Colliders")]
    public SphereCollider LeftHandCarpals;
    public SphereCollider RightHandCarpals;

    public SphereCollider LeftFootLateralCuneiform;
    public SphereCollider RightFootLateralCuneiform;

    public SphereCollider CraniumCollider;

    public PlayerStats thisStats;

    private PlayerMovement pm;
    private void Awake() {
        thisStats = GetComponent<PlayerStats>();
        pm = GetComponent<PlayerMovement>();
    }
    public void SwitchFeetOff()
    {
        LeftFootLateralCuneiform.enabled = false;
        RightFootLateralCuneiform.enabled = false;
    }

    public void SwitchFeetOn()
    {
        LeftFootLateralCuneiform.enabled = true;
        RightFootLateralCuneiform.enabled = true;
    }

    public void SwitchHandsOn()
    {
        LeftHandCarpals.enabled = true;
        RightHandCarpals.enabled = true;
    }

    public void SwitchHandsOff()
    {
        LeftHandCarpals.enabled = false;
        RightHandCarpals.enabled = false;
    }

    public void SwitchCraniumOn()
    {
        CraniumCollider.enabled = true;
    }

    public void SwitchCraniumOff()
    {
        CraniumCollider.enabled = false;
    }


    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hit")
        {
            hitPos = other.transform.position;

            float totalDmg = (pm.isBlocking) ? (other.GetComponent<Hit>().Damage * BlockPercent) : (other.GetComponent<Hit>().Damage  );
            thisStats.TakeDamage(totalDmg);
            Debug.Log("zooped for " + totalDmg.ToString() + " damage");

            other.GetComponent<SphereCollider>().enabled = false;
        }
    }

       private void OnDrawGizmos() { 
 
        float calcTopY = transform.position.y + blockTopY; 
        float calcBotY = transform.position.y + blockBottomY; 
        Gizmos.color = ((hitPos.y < calcTopY) && (hitPos.y > calcBotY)) ? (Color.red) : (Color.white); 
        Gizmos.DrawSphere(hitPos, 0.1f); 
    } 
}
