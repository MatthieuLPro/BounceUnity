using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lizard {
    namespace Interaction {
        /// <summary>
        ///     Concern : Launch the stamina max update
        ///     Usage : Call by the specific interaction
        ///     Dependency : 
        ///         - ???
        /// </summary>
        public class StaminaMaxUpdater
        {
            public void Call() {
                Debug.Log("Update stamina max");
            }
        }
    }
}
