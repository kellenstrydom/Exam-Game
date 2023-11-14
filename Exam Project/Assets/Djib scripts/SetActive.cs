using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    //public string sceneToLoad;
    public GameObject InfoText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InfoText.SetActive(true);
        }
        else
        {
            InfoText.SetActive(false);
        }
    }
}
