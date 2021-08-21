using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lizard {
    namespace Interaction {
        public class Launcher : MonoBehaviour
        {
            StaminaMaxUpdater staminaMaxUpdater;
            void Start() {
                staminaMaxUpdater = new StaminaMaxUpdater();
            }

            public void Call() {
                Debug.Log("Launch lizard interaction");
                staminaMaxUpdater.Call();
            }
        }
    }
}
