using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    /// <summary>
    ///     Concern : Add / remove new interaction.
    ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "Interaction" with 1 nested component "CurrentInteraction"
    ///     Dependency : 
    ///         - Interaction.Dictionary.InteractionsList
    /// </summary>
    public class NewInteractionTrigger : MonoBehaviour
    {
        private Dictionary.InteractionsList interactions = Interaction.Dictionary.InteractionsList.GetInstance();

        [Header("Interaction to add / remove")]
        [SerializeField]
        private Dictionary.InteractionsList.InteractionName interaction;

        public void OnTriggerEnter2D(Collider2D collider) {
            if (collider.tag == Interaction.Constants.PlayerTag) {
                System.Type newInteraction = GetInteractionType();
                findCurrentInteraction(collider).AddComponent(newInteraction);
            }
        }

        public void OnTriggerExit2D(Collider2D collider) {
            if (collider.tag == Interaction.Constants.PlayerTag) {
                System.Type newInteraction = GetInteractionType();
                Destroy(findCurrentInteraction(collider).GetComponent(newInteraction));
            }
        }

        private System.Type GetInteractionType() {
            return interactions.GetTypeFromDictionary(interaction);
        }

        private GameObject findCurrentInteraction(Collider2D collider) {
            return collider.transform.Find(Interaction.Constants.MainComponentName).transform.Find(Interaction.Constants.NestedComponentName).gameObject;
        }
    }
}
