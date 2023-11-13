using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    private string[] currentLines;
    private int currentIndex = 0;

    private bool isDialogueActive = false;

    private Coroutine typeLineCoroutine;

    public void StartDialogue(string[] lines)
    {
        currentLines = lines;
        currentIndex = 0;
        textComponent.text = string.Empty;
        isDialogueActive = true;

        if (typeLineCoroutine != null)
        {

            StopCoroutine(typeLineCoroutine);
        }

        typeLineCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        int charIndex = 0;
        string currentLine = "";

        while (charIndex < currentLines[currentIndex].Length)
        {
            if (!isDialogueActive)
            {
                yield break;
            }

            currentLine += currentLines[currentIndex][charIndex];
            textComponent.text = currentLine;
            charIndex++;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public bool NextLine()
    {
        if (currentIndex < currentLines.Length - 1)
        {
            currentIndex++;
            textComponent.text = string.Empty;

            if (typeLineCoroutine != null)
            {

                StopCoroutine(typeLineCoroutine);
            }

            typeLineCoroutine = StartCoroutine(TypeLine());
            return true;
        }
        else
        {
            isDialogueActive = false;
            return false;
        }
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
