using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuOptions : MonoBehaviour
{
    [Header("Associated button")]
    [SerializeField]
    private Image image;

    public abstract void Call();
    public void UpdateImageColor(Color32 newColor) {
        image.color = newColor;
    }
}
