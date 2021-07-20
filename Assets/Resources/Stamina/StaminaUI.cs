using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaUI : MonoBehaviour
{
    [Header("Image game object")]
    [SerializeField]
    private GameObject go_image;

    [Header("Stamina data")]
    [SerializeField]
    private StaminaData staminaData;

    private RectTransform imageRectTransform;

    private void Start() {
        imageRectTransform = go_image.GetComponent<RectTransform>();
    }

    void Update() {
        if (!staminaData.StaminaIsMax()) {
            imageRectTransform.sizeDelta = newSize();
        }
    }

    private Vector2 newSize() {
        float currentSize = staminaData.currentStamina * 100 / staminaData.maxStamina; 
        return new Vector2(currentSize, currentSize);
    }
}
