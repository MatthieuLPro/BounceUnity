using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueText;
    private Coroutine typingCoroutine;

    public Animator textDisplayAnimator;

    public void Call() {
        if (typingCoroutine != null) {
            StopCoroutine(typingCoroutine);
        }
        if (index == 0 && textDisplay.text.Length == 0) {
            // First lecture
            typingCoroutine = StartCoroutine(TypeText(index));
        } else if (textDisplay.text.Length < sentences[index].Length - 1) {
            // Finish the sentence if reading
            textDisplay.text = sentences[index];
            continueText.SetActive(true);
        } else {
            // Go to next sentence if sentence is finished
            NextSentence();
        }
    }

    public bool IsFinished() {
        return (index == 0 && textDisplay.text.Length == 0);
    }

    private IEnumerator TypeText(int currentIndex) {
        foreach(char letter in sentences[currentIndex].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        continueText.SetActive(true);
    }

    private void NextSentence() {
        ResetSentence();
        if(index < sentences.Length - 1) {
            index++;
            typingCoroutine = StartCoroutine(TypeText(index));
        } else {
            index = 0;
        }
    }

    private void ResetSentence() {
        // Set animator
        // textDisplayAnimator.SetTrigger("Change");
        continueText.SetActive(false);
        textDisplay.text = "";
    }
}
