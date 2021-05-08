using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignTextDisplay : MonoBehaviour
{
    [Header("Text box to display")]
    [SerializeField]
    private GameObject textBox;
    private GameObject currentText;
    private List<GameObject> texts;

#region Unity Functions
    void Start()
    {
        texts = new List<GameObject>();
        foreach(Transform child in transform)
        {
            texts.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }
#endregion
#region Public Functions
    public void Call(string textName, bool activation) {
        texts.Find(text => text.name == textName).SetActive(activation);
        textBox.SetActive(activation);
    }
#endregion
}
