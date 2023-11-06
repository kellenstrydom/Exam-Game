using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    public float attackRange;
    public float attackSpeed;
    public float castTime;
    private bool canAttack = true;

    [Header("Projectile")] 
    public GameObject projectile;
    public float damage;
    public float projectileForce;
    public Transform spawnPos;

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
        Debug.Log(name + " fired");
        GameObject obj = Instantiate(projectile, spawnPos.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(projectileForce * new Vector3(target.position.x - spawnPos.position.x,0,target.position.z - spawnPos.position.z).normalized, ForceMode.Impulse);
        obj.GetComponent<Projectile>().damageAmount = damage;
        yield return new WaitForSeconds(1 / attackSpeed);
        
        Debug.Log(name + " ready to fire");
        canAttack = true;
    }
}
