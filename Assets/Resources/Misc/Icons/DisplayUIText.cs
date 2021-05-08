using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayUIText : MonoBehaviour
{   
    [Header("Text name to display")]
    [SerializeField]
    private string textName;

    [Header("SignText displayer")]
    [SerializeField]
    private SignTextDisplay displayer;

#region Unity Functions
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            displayer.Call(textName, true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            displayer.Call(textName, false);
        }
    }
#endregion
}
