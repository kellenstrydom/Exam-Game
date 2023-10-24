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
      if (Input.GetButtonDown("Horizontal"))
        {
            Run();
            NotTalking();
        }
      else
        {
            Talk();
            NotRunning();
        }

      if (Input.GetButtonDown("Vertical"))
        {
            Run();
            NotTalking();
        }
        else
        {
            Talk();
            NotRunning();
        }
    }

    public void Run()
    {
        animator.SetBool("Run", true);
    }

    public void Talk() 
    {
        animator.SetBool("Talk", true);
    }

    public void NotRunning()
    {
        animator.SetBool("Run", false);
    }

    public void NotTalking()
    {
        animator.SetBool("Talk", false);
    }
}
