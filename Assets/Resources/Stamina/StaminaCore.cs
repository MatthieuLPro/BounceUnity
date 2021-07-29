using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    public class StaminaCore : MonoBehaviour
    {
        [SerializeField]
        private StaminaData data;

        private Stamina.StaminaRecoverer staminaRecoverer;
        private Stamina.StaminaConsumer staminaConsumer;

    #region Unity Functions
        void Start() {
            staminaRecoverer = gameObject.AddComponent<Stamina.StaminaRecoverer>();
            staminaRecoverer.Initialize(data);
            staminaConsumer = gameObject.AddComponent<Stamina.StaminaConsumer>();
            staminaConsumer.Initialize(data);
        }

        void Update() {
            if (!data.IsConsuming()) {
                staminaRecoverer.TryToRecover(1);
            }
        }
    #endregion
    #region Public Functions
        public void ConsumeStamina(int value) {
            staminaConsumer.TryToConsume(value);
        }

        public void UpdateConsumingStamina(bool value) {
            staminaConsumer.UpdateConsumingState(value);
        }
    #endregion
    }
}
