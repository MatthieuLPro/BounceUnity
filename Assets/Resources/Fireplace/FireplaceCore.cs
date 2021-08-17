using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fireplace {
    /// <summary>
    /// Concern : Manage the logic of a fireplace
    /// Usage : Attached to a gameObject
    /// </summary>
    public class FireplaceCore : MonoBehaviour
    {
        private enum States {
            switchOff,
            switchOn,
        }
        private States currentState;

        void Start() {
            currentState = States.switchOff;
        }

        public void SwitchOn() {
            currentState = States.switchOn;
        }

        public void SaveGame() {
            Debug.Log("Save the game");
        }
    }
}
