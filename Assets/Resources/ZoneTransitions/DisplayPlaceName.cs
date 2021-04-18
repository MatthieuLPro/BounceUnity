using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlaceName : MonoBehaviour
{
    [Header("Place name")]
    [SerializeField]
    private string placeName;

    [Header("Object with text from canvas to display place name")]
    [SerializeField]
    private GameObject go_textToUpdate;
    private Text textToUpdate;

    void Start() {
        textToUpdate = go_textToUpdate.GetComponent<Text>();
    }

    public void DisplayText() {
        StartCoroutine(TextEffectCo());
    }

    private IEnumerator TextEffectCo() {
        textToUpdate.text = placeName;
        go_textToUpdate.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        go_textToUpdate.SetActive(false);
    }
}
