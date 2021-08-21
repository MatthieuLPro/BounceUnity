using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Trigger {
        /// <summary>
        ///     Concern : Add / remove new interaction.
        ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "Interaction" with 1 nested component "CurrentInteraction"
        ///     Dependency : 
        ///         - Dictionary.LizardInteraction
        /// </summary>
        public class LizardInteraction : CoreNewInteraction
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
