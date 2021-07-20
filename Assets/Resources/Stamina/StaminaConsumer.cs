using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    public class StaminaConsumer : MonoBehaviour
    {
        private StaminaData data;
        private bool consumingIsLaunched = false;

        #region Public Functions
            public void Initialize(StaminaData staminaData) {
                if (data != null) {
                    return;
                }
                data = staminaData;
            }

            public void Call(int value) {
                if (!IsConsuming() && !data.StaminaIsEmpty()) {
                    StartCoroutine(ConsumingStamina(value));
                }
            }
        #endregion
        #region Private Functions
            private IEnumerator ConsumingStamina(int value) {
                consumingIsLaunched = true;
                yield return new WaitForSeconds(ConsumingSpeed());
                data.UpdateCurrentStamina(value * -1);
                consumingIsLaunched = false;
            }

            private bool IsConsuming() {
                return consumingIsLaunched;
            }

            private bool StaminaIsEmpty() {
                return data.StaminaIsNotEmpty();
            }

            private float ConsumingSpeed() {
                return data.ConsumingSpeed();
            }
        #endregion
    }
}
