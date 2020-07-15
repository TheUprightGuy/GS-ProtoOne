using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float HitCooldown = 0.5f;
    private GameObject hitCollider = null;

    public SphereCollider LeftHandCarpals;
    public SphereCollider RightHandCarpals;

    public SphereCollider LeftFootLateralCuneiform;
    public SphereCollider RightFootLateralCuneiform;

    public PlayerStats thisStats;

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
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Hit")
        {
            thisStats.TakeDamage(1.0f);
            Debug.Log("zoop");
        }
    }
}
