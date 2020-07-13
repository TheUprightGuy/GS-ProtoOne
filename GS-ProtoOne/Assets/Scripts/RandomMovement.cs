using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class RandomMovement : MonoBehaviour
{
    public float maxRangeFromCenter = 15;
    public float timeToComplete = 30;
    public float rollStrength = 5;

    private LookAtConstraint _lookAtConstraint;
    private void Awake()
    {
        _lookAtConstraint = this.GetComponent<LookAtConstraint>();
        rollStrength *= -1;
        _lookAtConstraint.roll = rollStrength;
    }

    private void FixedUpdate()
    {
        if(LeanTween.isTweening(this.gameObject)) return;
        LeanTween.moveX(this.gameObject, maxRangeFromCenter, timeToComplete).setEaseInOutSine();
        LeanTween.value(this.gameObject, UpdateRollValue, rollStrength, rollStrength * -1, timeToComplete);
        maxRangeFromCenter *= -1;
        rollStrength *= -1;
    }

    private void UpdateRollValue(float val)
    {
        _lookAtConstraint.roll = val;
    }
}
