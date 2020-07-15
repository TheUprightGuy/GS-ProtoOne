using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float HitCooldown = 0.5f;
    private GameObject hitCollider = null;


    
    private PlayerStats thisStats;

    public float blockTopY = 0.0f;
    public float blockBottomY = 1.0f;



    [Header("Colliders")]
    public SphereCollider LeftHandCarpals;
    public SphereCollider RightHandCarpals;

    public SphereCollider LeftFootLateralCuneiform;
    public SphereCollider RightFootLateralCuneiform;
    private void Awake() {
        thisStats = GetComponent<PlayerStats>();
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

    private Vector3 hitPos = Vector3.zero;
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hit")
        {
            hitPos = other.transform.position;
            thisStats.TakeDamage(1.0f);
            Debug.Log("zoop");
        }
    }

    private void OnDrawGizmos() {


        float calcTopY = transform.position.y + blockTopY;
        float calcBotY = transform.position.y + blockBottomY;
        Gizmos.color = ((hitPos.y < calcTopY) && (hitPos.y > calcBotY)) ? (Color.red) : (Color.white);
        Gizmos.DrawSphere(hitPos, 0.1f);
    }
}
