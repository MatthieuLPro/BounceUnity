using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Trigger {
        /// <summary>
        ///     Concern :
        ///         - Add the component FireplaceInteraction when a player enter in the boxCollider.
        ///         - Remove the component FireplaceInteraction when a player exit from the boxCollider.
        ///     Usage : Attached to a gameObject with 1 boxCollider
        ///     Dependency : 
        ///         - Dictionary.FireplaceInteraction
        /// </summary>
        public class FireplaceTrigger : CoreTrigger
        {
            public override void RemoveInteraction(GameObject interactionObject) {
                Destroy(interactionObject.GetComponent(typeof(Dictionary.FireplaceInteraction)));
            }

            public override void AddInteraction(GameObject interactionObject) {
                Dictionary.FireplaceInteraction.CreateComponent(interactionObject, gameObject);
            }
        }
    }
}
