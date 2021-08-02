using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stamina {
    /// <summary>
    ///     Concern : Manage the logic of stamina consuming and recovering.
    ///     Usage : Attached to a gameObject
    ///     Dependency : 
    ///         - Stamina.StaminaRecoverer
    ///         - Stamina.StaminaConsumer
    ///         - StaminaData
    /// </summary>
    public class StaminaCore : MonoBehaviour
    {
        public StaminaData data;

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
            if (!data.StaminaIsEmpty() && data.IsConsuming()) {
                staminaConsumer.TryToConsume(1);
            }
            else if (!data.CurrentStaminaIsFull()) {
                staminaRecoverer.TryToRecover(1);
            }
        }
    #endregion
    #region Public Functions
        public void UpdateConsumingStamina(bool value) {
            staminaConsumer.UpdateConsumingState(value);
        }
        public bool CanConsumeStamina() {
            return !data.StaminaIsEmpty();
        }
    #endregion
    }
}
