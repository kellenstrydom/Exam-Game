using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public enum ActionState
    {
        idle,
        chase,
        attack
    }
    
    
    private NavMeshAgent agent;
    private Transform target;
 
    public float sightRange;
    public float leashRange;
    public float attackRange;
    

    public ActionState actionState;

    public bool OutOfLeashRange;

    public float LeashTime;

    public RangedEnemyAttack _rangedEnemyAttack;
    public MeleeEnemy _meleeEnemy;
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        actionState = ActionState.idle;

        if (GetComponent<RangedEnemyAttack>())
        {
            _rangedEnemyAttack = GetComponent<RangedEnemyAttack>();
            attackRange = _rangedEnemyAttack.attackRange;
        }       
        
        if (GetComponent<MeleeEnemy>())
        {
            _meleeEnemy = GetComponent<MeleeEnemy>();
            attackRange = _meleeEnemy.attackRange;

        }        
        
    }

    private void Update()
    {
        if (target == null) return;

        switch (actionState)
        {
            case ActionState.idle: 
                IdleDo();
                break;
            case ActionState.chase:
                ChaseDo();
                break;
            case ActionState.attack:
                AttackDo();
                break;
        }
    }

    void IdleDo()
    {
        agent.Stop();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit,
                sightRange) && hit.transform.CompareTag("Player"))
        {
            //Debug.Log(gameObject.name + " hit " + hit.transform.name);
            actionState = ActionState.chase;

        }
        else
        {
            //Debug.Log(gameObject.name + " hit nothing");
        }
    }

    void ChaseDo()
    {
        agent.Resume();
        agent.SetDestination(target.position);
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit,
                leashRange) || !hit.transform.CompareTag("Player"))
        {
            if (!OutOfLeashRange)
            {
                StartCoroutine("StopChase");
                OutOfLeashRange = true;
            }
        }
        else
        {
            if (OutOfLeashRange)
            {
                StopCoroutine("StopChase");
                OutOfLeashRange = false;
            }
        }
        
        
        CheckAttackRange();
    }

    void CheckAttackRange()
    {
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, (target.position - transform.position).normalized, out hit,
                attackRange) || !hit.transform.CompareTag("Player"))
        {
            actionState = ActionState.chase;
        }
        else
        {
            actionState = ActionState.attack;
            agent.Stop();
        }
        
        
    }

    // void ResetAttack()
    // {
    //     actionState = ActionState.chase;
    // }
    void AttackDo()
    {
        float castTime = 0;
        transform.forward =
            new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z)
                .normalized;
        _rangedEnemyAttack?.Attack(target, ref castTime);
        _meleeEnemy?.Attack(target, ref castTime);
        
        // if (_rangedEnemyAttack.Attack(target, ref castTime))
        // {
        //     // nothing
        // }
        
        CheckAttackRange();
    }

    IEnumerator StopChase()
    {
        yield return new WaitForSeconds(LeashTime);

        actionState = ActionState.idle;
        Debug.Log(name + " idle reset");
    }


    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         int randomDamage = Random.Range(1, 6);
    //     }
    // }
}
