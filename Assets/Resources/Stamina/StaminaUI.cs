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
        [Header("Current stamina image")]
        [SerializeField]
        private RectTransform currentStaminaImage;

        private StaminaData staminaData;


        private void Start() {
            staminaData = GetComponent<Stamina.StaminaCore>().data;
        }

        void Update() {
            if (!staminaData.StaminaIsMax()) {
                currentStaminaImage.sizeDelta = newSize();
            }
        }

        private Vector2 newSize() {
            float currentSize = staminaData.currentStamina * 100 / staminaData.maxStamina; 
            return new Vector2(currentSize, currentSize);
        }
    }
}
