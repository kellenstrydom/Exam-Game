using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public string[] lines; // Define the dialogue lines for each NPC in the Inspector
    public GameObject interactText;

    private bool isInRange = false;
    private Dialogue dialogue;
    private bool spokeTo;

    private void Start()
    {
        dialogue = dialoguePanel.GetComponent<Dialogue>();
        dialoguePanel.SetActive(false); // Initially, set the dialoguePanel to inactive.
        spokeTo = false;
    }

    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!spokeTo)
                {
                    GameObject.FindWithTag("Level Manager").GetComponent<LevelManager>().SpeakWithNPC(transform);
                    spokeTo = true;
                }                
                
                interactText.SetActive(false);
                dialoguePanel.SetActive(true); // Set the dialogue panel active when initiating a dialogue.
                dialogue.StartDialogue(lines);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (dialoguePanel.activeSelf)
                {
                    if (!dialogue.NextLine())
                    {
                        dialoguePanel.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            interactText.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }
}
