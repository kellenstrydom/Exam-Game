using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0 || Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0) 
        {
            Run();
         
        }
        else 
        {
            NotRunning();
        }

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

}



