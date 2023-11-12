using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool hasNote = true;
    public bool hasImage = false;
    public string noteText = "This is a note.";
    public Sprite image;
    public GameObject note;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        note.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;
        note.SetActive(false);
    }

}