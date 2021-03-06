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
        ///         - Lizard.Interaction.Launcher
        /// </summary>
        public class LizardInteraction : CoreInteraction
        {
            public static LizardInteraction CreateComponent (GameObject where, GameObject holder) {
                LizardInteraction interaction = where.AddComponent<LizardInteraction>();
                interaction.toDisplay = "Eat the lizard interaction";
                interaction.holder = holder;
                return interaction;
            }

            public override void Call() {
                Debug.Log(toDisplay);
                // Stop the game
                // Do an animation
                holder.transform.Find("Interaction").GetComponent<Lizard.Interaction.Launcher>().Call();
                // Destroy the holder
                // Resume the game
            }
        }
    }
}
