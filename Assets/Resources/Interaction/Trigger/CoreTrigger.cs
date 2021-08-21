using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Trigger {
        /// <summary>
        ///     Concern :
        ///         - Add an interaction when a player enter in the boxCollider.
        ///         - Remove an interaction when a player exit from the boxCollider.
        ///     Usage : All interaction trigger must inherite from the class CoreTrigger (except defaultTrigger)
        ///     Dependency : 
        ///         - Interaction.Constants
        /// </summary>
        public class CoreTrigger : MonoBehaviour
        {
            public void OnTriggerEnter2D(Collider2D collider) {
                if (collider.tag == Interaction.Constants.PlayerTag) {
                    AddInteraction(findCurrentInteraction(collider));
                }
            }

            public void OnTriggerExit2D(Collider2D collider) {
                if (collider.tag == Interaction.Constants.PlayerTag) {
                    RemoveInteraction(findCurrentInteraction(collider));
                }
            }

            public virtual void RemoveInteraction(GameObject interactionObject){} 
            public virtual void AddInteraction(GameObject interactionObject){}

            private GameObject findCurrentInteraction(Collider2D collider) {
                return collider.transform.Find(Interaction.Constants.MainComponentName).transform.Find(Interaction.Constants.NestedComponentName).gameObject;
            }
        }
    }    
}
