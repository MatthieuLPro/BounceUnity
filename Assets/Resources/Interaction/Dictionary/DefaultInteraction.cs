using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        /// <summary>
        ///     Concern : This is the default interaction. This interaction do
        ///     nothing when the player press the button. It's attached by 
        ///     default when the player does not have an other interaction.
        ///     Usage : TODO => Used by PlayerInput
        ///     Dependency : 
        ///         - ???
        /// </summary>
        public class DefaultInteraction : InteractionCore
        {
            void Start() {
                toDisplay = "From null";
            }
        }
    }
}