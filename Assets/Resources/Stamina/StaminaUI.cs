using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    /// <summary>
    ///     StaminaUI is a class we attached to a gameObject
    ///     It manages the logic to display Stamina values in UI.
    ///     Dependency : 
    ///         - Stamina.StaminaCore
    /// </summary>
    public class StaminaUI : MonoBehaviour
    {
        [Header("Image rect transform")]
        [SerializeField]
        private RectTransform imageRectTransform;

        private StaminaData staminaData;


        private void Start() {
            staminaData = GetComponent<Stamina.StaminaCore>().data;
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
}
