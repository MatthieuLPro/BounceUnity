using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    /// <summary>
    ///     Concern : Add / remove default interaction.
    ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "Interaction" with 1 nested component "CurrentInteraction"
    ///     Dependency : 
    ///         - Interaction.Dictionary.InteractionsList
    /// </summary>
    public class DefaultInteractionTrigger : MonoBehaviour
    {
        private Dictionary.InteractionsList interactions = Interaction.Dictionary.InteractionsList.GetInstance();

        public void OnTriggerEnter2D(Collider2D collider) {
            if (collider.tag == Interaction.Constants.PlayerTag) {
                RemoveDefaultInteraction(findCurrentInteraction(collider));
            }
        }

        public void OnTriggerExit2D(Collider2D collider) {
            if (collider.tag == Interaction.Constants.PlayerTag) {
                AddDefaultInteraction(findCurrentInteraction(collider));
            }
        }

        private void RemoveDefaultInteraction(GameObject interactionObject) {
            System.Type interactionNull = interactions.GetDefaultInteraction();
            Destroy(interactionObject.GetComponent(interactionNull));
        }

        private void AddDefaultInteraction(GameObject interactionObject) {
            System.Type interactionNull = interactions.GetDefaultInteraction();
            interactionObject.AddComponent(interactionNull);
        }

        private GameObject findCurrentInteraction(Collider2D collider) {
            return collider.transform.Find(Interaction.Constants.MainComponentName).transform.Find(Interaction.Constants.NestedComponentName).gameObject;
        }
    }
}
