using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackClass
{
    public GameObject hitBox;
    public float startDelay;
    public float hitBoxActiveDuration;
    public float endDelay;

    public void Attack()
    {
        hitBox.SetActive(true);
        //Invoke("EndAttack",duration);
    }

    public void EndAttack()
    {
        hitBox.SetActive(false);
    }
}
