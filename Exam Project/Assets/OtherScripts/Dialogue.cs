using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private string currentLine;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == currentLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = currentLine;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        currentLine = lines[index];
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        int charIndex = 0;
        currentLine = "";  // Initialize the current line
        while (charIndex < lines[index].Length)
        {
            currentLine += lines[index][charIndex];
            textComponent.text = currentLine;
            charIndex++;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            currentLine = string.Empty;
            textComponent.text = currentLine;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
