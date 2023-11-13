using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>().Complete();
    }
}
