using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        enabled = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropKick()
    {
        enemyAnimator.SetBool("Dropkicking", true);
    }

    public void NotDropKick()
    {
        enemyAnimator.SetBool("Dropkicking", false);
    }

    public void Walking()
    {
        enemyAnimator.SetBool("Walking", true);
    }


    public void NotWalking()
    {
        enemyAnimator.SetBool("Walking", false);
    }

    public void Throwing()
    {
        enemyAnimator.SetBool("Throwing", true);
    }

    public void NotThrowing()
    {
        enemyAnimator.SetBool("Throwing", false);
    }


}
