using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    public class StaminaConsumer : MonoBehaviour
    {
        private StaminaData data;
        private Coroutine staminaConsuming = null;

        #region Public Functions
            public void Initialize(StaminaData staminaData) {
                if (data != null) {
                    return;
                }
                data = staminaData;
            }

            public void TryToConsume(int value) {
                if (StaminaIsEmpty() && !IsConsuming()) {
                    staminaConsuming = StartCoroutine(ConsumingStamina(value));
                }
            }

            public void UpdateConsumingState(bool value) {
                data.UpdateConsumingState(value);
            }
        #endregion
        #region Private Functions
            private bool StaminaIsEmpty() {
                return data.StaminaIsNotEmpty();
            }

            private bool IsConsuming() {
                return staminaConsuming != null;
            }
            
            private IEnumerator ConsumingStamina(int value) {
                yield return new WaitForSeconds(ConsumingSpeed());
                data.UpdateCurrentStamina(value * -1);
                staminaConsuming = null;
            }            

            private float ConsumingSpeed() {
                return data.consumingSpeed;
            }
        #endregion
    }
}
