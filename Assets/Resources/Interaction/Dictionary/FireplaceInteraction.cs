using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        /// <summary>
        ///     Concern :
        ///         - Create component with specific information
        ///         - Facade to call the specific launcher
        ///     Usage : Added by a newInteractionTrigger and launched by InteractionLauncher
        ///     Dependency : 
        ///         - Firplace.Interaction.Launcher
        /// </summary>
        public class FireplaceInteraction : CoreInteraction
        {
            public static FireplaceInteraction CreateComponent (GameObject where, GameObject holder) {
                FireplaceInteraction interaction = where.AddComponent<FireplaceInteraction>();
                interaction.toDisplay = "Active fireplace interaction";
                interaction.holder = holder;
                return interaction;
            }

            public override void Call() {
                Debug.Log(toDisplay);
                // Stop the game
                // Do an animation
                holder.transform.Find("Interaction").GetComponent<Fireplace.Interaction.Launcher>().Call();
                // Destroy the holder
                // Resume the game
            }
        }
    }
}
