using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    public Animator enemyAnimator;
    public EnemyBehaviour _behaviour;

    public EnemyBehaviour.ActionState preActionState;
    
    // Start is called before the first frame update
    void Start()
    {
        enabled = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (preActionState)
        {
            case EnemyBehaviour.ActionState.chase:
                //Walking(_behaviour.actionState == preActionState);
                break;
            case EnemyBehaviour.ActionState.attack:
                if (_behaviour._meleeEnemy != null)
                    DropKick(_behaviour.actionState == preActionState);
                else
                    Throwing(_behaviour.actionState == preActionState);
                break;
        }

        switch (_behaviour.actionState)
        {
            case EnemyBehaviour.ActionState.chase:
                Walking(true);
                break;
            case EnemyBehaviour.ActionState.attack:
                if (_behaviour._meleeEnemy != null)
                    DropKick(_behaviour.actionState == preActionState);
                else
                    Throwing(_behaviour.actionState == preActionState);
                break;
            case EnemyBehaviour.ActionState.idle:
                Walking(false);
                break;
        }

        preActionState = _behaviour.actionState;
    }

    public void DropKick(bool b)
    {
        enemyAnimator.SetBool("Dropkicking", b);
    }

    public void NotDropKick()
    {
        enemyAnimator.SetBool("Dropkicking", false);
    }

    public void Walking(bool b)
    {
        enemyAnimator.SetBool("Walking", b);
    }


    public void NotWalking()
    {
        enemyAnimator.SetBool("Walking", false);
    }

    public void Throwing( bool b)
    {
        enemyAnimator.SetBool("Throwing", b);
    }

    public void NotThrowing()
    {
        enemyAnimator.SetBool("Throwing", false);
    }


}
