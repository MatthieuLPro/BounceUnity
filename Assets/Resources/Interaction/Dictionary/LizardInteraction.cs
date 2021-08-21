using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        /// <summary>
        ///     Concern : Orchestrate the lizard interaction
        ///     Usage : Added by a newInteractionTrigger and launched by InteractionLauncher
        ///     Dependency : 
        ///         - Lizard.Interaction
        /// </summary>
        public class LizardInteraction : CoreInteraction
        {
            // private Lizard.Interaction.Animation animation;
            // private Lizard.Interaction.StaminaMaxUpdater staminaMaxUpdater;
            public static LizardInteraction CreateComponent (GameObject where, GameObject holder) {
                LizardInteraction interaction = where.AddComponent<LizardInteraction>();
                interaction.toDisplay = "Eat the lizard";
                interaction.holder = holder;
                return interaction;
            }

            public override void Call() {
                Debug.Log(toDisplay);
                Debug.Log(holder);
            }
        }
    }
}
