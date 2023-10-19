using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackClass
{
    [Range(0.01f, 3.0f)]
    [Tooltip("The percent of the weapon damage the attack will deal")]
    public float damageMultiplier = 1f;
    
    public GameObject hitBox;
    public float startDelay;
    public float hitBoxActiveDuration;
    public float endDelay;

    public float chargeCost;

    public void Attack(float weaponDamage)
    {
        hitBox.GetComponent<AttackHitBox>().damageToDeal = weaponDamage * damageMultiplier;
        hitBox.SetActive(true);
        //Invoke("EndAttack",duration);
    }

    public void EndAttack()
    {
        hitBox.SetActive(false);
    }
}
