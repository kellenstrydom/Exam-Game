using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("HITTTT");
        }
    }
}
