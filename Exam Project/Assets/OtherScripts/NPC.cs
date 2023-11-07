using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject interactText;
    public GameObject dialoguePanel;

    private bool isInRange = false;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {

            interactText.SetActive(false);
            dialoguePanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            isInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            isInRange = false;
            interactText.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }
}
