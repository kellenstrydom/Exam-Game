using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private Animator animator;

    public PlayerControls.ActionState preActionState;
    public PlayerControls _Controls;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        _Controls = GetComponentInParent<PlayerControls>();

        preActionState = _Controls.currentState;

    }

    private void Update()
    {
        switch (preActionState)
        {
            case PlayerControls.ActionState.moving:
                Run(_Controls.currentState == preActionState);
                break;
            case PlayerControls.ActionState.attacking:
                Attacking(_Controls.currentState == preActionState);
                break;
            case PlayerControls.ActionState.dashing:
                Dashing(_Controls.currentState == preActionState);
                break;
        }

        switch (_Controls.currentState)
        {
            case PlayerControls.ActionState.moving:
                Run(_Controls.currentState == preActionState);
                break;
            case PlayerControls.ActionState.attacking:
                Attacking(_Controls.currentState == preActionState);
                break;
            case PlayerControls.ActionState.dashing:
                Dashing(_Controls.currentState == preActionState);
                break;
        }

        preActionState = _Controls.currentState;
    }

    public void Run(bool isOn)
    {
        animator.SetBool("isRunning", isOn);
    }
    
    public void Attacking(bool isOn)
    {
        animator.SetBool("isAttackinhg", isOn);
    }
    
    public void  Dashing(bool isOn)
    {
        animator.SetBool("isDashing", isOn);
    }
    
    public void Run()
    {
        animator.SetBool("isRunning", true);
    }


    public void NotRunning()
    {
        animator.SetBool("isRunning", false); 
    }

    public void Attackinhg()
    {
        animator.SetBool("isAttackinhg", true);
    }


    public void NotAttackinhg()
    {
        animator.SetBool("isAttackinhg", false);
    }

    public void  Dashing()
    {
        animator.SetBool("isDashing", true);
    }


    public void NotDashin()
    {
        animator.SetBool("isDashing", false);
    }

}



