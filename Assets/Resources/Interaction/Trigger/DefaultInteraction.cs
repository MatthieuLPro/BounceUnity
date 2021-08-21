using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Trigger {
        /// <summary>
        ///     Concern : Add / remove default interaction.
        ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "Interaction" with 1 nested component "CurrentInteraction"
        ///     Dependency : 
        ///         - Dictionary.DefaultInteraction
        /// </summary>
        public class DefaultInteraction : MonoBehaviour
        {
            public void OnTriggerEnter2D(Collider2D collider) {
                if (collider.tag == Interaction.Constants.PlayerTag) {
                    RemoveInteraction(findCurrentInteraction(collider));
                }
            }

            public void OnTriggerExit2D(Collider2D collider) {
                if (collider.tag == Interaction.Constants.PlayerTag) {
                    AddInteraction(findCurrentInteraction(collider));
                }
            }

            public void RemoveInteraction(GameObject interactionObject) {
                Destroy(interactionObject.GetComponent(typeof(Dictionary.DefaultInteraction)));
            }

            public void AddInteraction(GameObject interactionObject) {
                Dictionary.DefaultInteraction.CreateComponent(interactionObject, null);
            }

            private GameObject findCurrentInteraction(Collider2D collider) {
                return collider.transform.Find(Interaction.Constants.MainComponentName).transform.Find(Interaction.Constants.NestedComponentName).gameObject;
            }
        }
    }    
}
