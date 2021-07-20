using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    public class StaminaRecoverer : MonoBehaviour
    {
        private StaminaData data;
        private bool recoveringIsLaunched = false;

        #region Public Functions
            public void Initialize(StaminaData staminaData) {
                if (data != null) {
                    return;
                }
                data = staminaData;
            }

            public void Call() {
                if (!IsRecovering() && !StaminaIsFull()) {
                    StartCoroutine(RecoverStamina());
                }
            }
        #endregion
        #region Private Functions
            private IEnumerator RecoverStamina() {
                recoveringIsLaunched = true;
                yield return new WaitForSeconds(RecoverSpeed());
                data.UpdateCurrentStamina(1);
                recoveringIsLaunched = false;
            }

            private bool IsRecovering() {
                return recoveringIsLaunched;
            }

            private bool StaminaIsFull() {
                return data.CurrentStaminaIsFull();
            }

            private float RecoverSpeed() {
                return data.RecoverSpeed();
            }
        #endregion
    }
}