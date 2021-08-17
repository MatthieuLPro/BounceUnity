using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    /// <summary>
    ///     Concern : Launch the specific interaction.
    ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "CurrentInteraction".
    /// </summary>
    public class InteractionLauncher : MonoBehaviour
    {
        public void Call() {
            GameObject currentInteraction = transform.Find(Interaction.Constants.NestedComponentName).gameObject;
            currentInteraction.SendMessage(Interaction.Constants.MethodName);
        }
    }
}
