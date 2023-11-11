using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public float attackRange;
    public float attackSpeed;
    public float castTime;
    private bool canAttack = true;

    [Header("Area")] 
    public GameObject hitBox;
    public float damage;
    public Transform spawnPos;
    public float lungeForce;

    private void Start()
    {
        hitBox.GetComponent<EnenmyAttackHitBox>().damageAmount = damage;
    }

    public bool Attack(Transform target, ref float castTime)
    {
        if (!canAttack) return false;
        StartCoroutine(DoAttack(target));
        castTime = this.castTime;
        return true;
    }
    

    IEnumerator DoAttack(Transform target)
    {
        canAttack = false;
        Debug.Log(name + " attack");
        hitBox.SetActive(true);
        GetComponent<Rigidbody>().AddForce(lungeForce*transform.forward,ForceMode.Impulse);

        float hitBoxDuration = hitBox.GetComponent<EnenmyAttackHitBox>().lifeTime;
        yield return new WaitForSeconds(hitBoxDuration);
        hitBox.SetActive(false);
        yield return new WaitForSeconds(1 / attackSpeed - hitBoxDuration);
        
        Debug.Log(name + " ready to fire");
        canAttack = true;
    }
}
