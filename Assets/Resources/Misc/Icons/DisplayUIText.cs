using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUIText : MonoBehaviour
{
    [Header("Text to display")]
    [SerializeField]
    private GameObject textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        textToDisplay.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            textToDisplay.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            textToDisplay.SetActive(false);
        }
    }
}
