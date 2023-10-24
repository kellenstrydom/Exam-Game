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
      if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
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
}



