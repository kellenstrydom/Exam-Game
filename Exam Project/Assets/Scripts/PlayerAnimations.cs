using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator animator;
    private 
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        animator.SetBool("isRunning", true);
    }


    public void NotRunning()
    {
        animator.SetBool("isRunning", false); 
    }
}