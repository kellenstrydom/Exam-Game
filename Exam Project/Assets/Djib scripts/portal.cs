using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //load.LoadWinScene();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
