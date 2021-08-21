using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Trigger {
        /// <summary>
        ///     Concern :
        ///         - Add the component LizardInteraction when a player enter in the boxCollider.
        ///         - Remove the component LizardInteraction when a player exit from the boxCollider.
        ///     Usage : Attached to a gameObject with 1 boxCollider
        ///     Dependency : 
        ///         - Dictionary.LizardInteraction
        /// </summary>
        public class LizardTrigger : CoreTrigger
        {
            public override void RemoveInteraction(GameObject interactionObject) {
                Destroy(interactionObject.GetComponent(typeof(Dictionary.LizardInteraction)));
            }

            public override void AddInteraction(GameObject interactionObject) {
                Dictionary.LizardInteraction.CreateComponent(interactionObject, gameObject);
            }
        }
    }
}
