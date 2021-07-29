using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    public class StaminaRecoverer : MonoBehaviour
    {
        private StaminaData data;
        private Coroutine staminaRecovering = null;

        #region Public Functions
            public void Initialize(StaminaData staminaData) {
                if (data != null) {
                    return;
                }
                data = staminaData;
            }

            public void TryToRecover(int value) {
                if (!StaminaIsFull() && !IsRecovering()) {
                    staminaRecovering = StartCoroutine(RecoverStamina(value));
                }
            }
        #endregion
        #region Private Functions
            private bool StaminaIsFull() {
                return data.CurrentStaminaIsFull();
            }

            private bool IsRecovering() {
                return staminaRecovering != null;
            }

            private IEnumerator RecoverStamina(int value) {
                yield return new WaitForSeconds(RecoverSpeed());
                data.UpdateCurrentStamina(value);
                staminaRecovering = null;
            }

            private float RecoverSpeed() {
                return data.recoverSpeed;
            }
        #endregion
    }
}