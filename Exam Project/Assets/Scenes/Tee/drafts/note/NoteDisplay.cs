using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour
{
    public Canvas noteCanvas;
    public Text noteText;
    public Image noteImage;

    public LayerMask interactableLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

                if (interactableObject != null)
                {
                    DisplayNoteOrImage(interactableObject);
                }
            }
        }
    }

    void DisplayNoteOrImage(InteractableObject interactableObject)
    {
        
        if (interactableObject.hasNote)
        {
            noteText.text = interactableObject.noteText;
            noteImage.gameObject.SetActive(false);
            noteText.gameObject.SetActive(true);
        }
        else if (interactableObject.hasImage)
        {
            noteImage.sprite = interactableObject.image;
            noteText.gameObject.SetActive(false);
            noteImage.gameObject.SetActive(true);
        }

        noteCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
        noteCanvas.transform.forward = -Camera.main.transform.forward;

        
        noteCanvas.gameObject.SetActive(true);
    }
}