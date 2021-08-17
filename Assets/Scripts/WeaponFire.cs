using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Serialization;

public class WeaponFire : MonoBehaviour
{
    public Animator weaponAnimator;
    public WeaponAnimationIndex[] weaponAnimations;
    public float maxAnimationTime;
    public WeaponAnimationIndex GetWeaponAnimationBlendValue(WeaponState weaponState)
    {
        return Array.Find(weaponAnimations, x => x.weaponState == weaponState);
    }
    
}


public enum WeaponState
{
    idle = 0,
    fire = 1
}

[Serializable]
public class WeaponAnimationIndex
{
    public WeaponState weaponState;
    public float animationValue;

    public WeaponAnimationIndex(WeaponState weaponState, float animationValue)
    {
        this.weaponState = weaponState;
        this.animationValue = animationValue;
    }
}