using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        /// <summary>
        ///     Concern : Singleton which is the dictionary of interactions.
        ///     Usage : Used by interactionAdder
        ///     Dependency : 
        ///         - Interaction.Dictionary.DefaultInteraction
        ///         - Interaction.Dictionary.InteractionTypeOne
        ///         - Interaction.Dictionary.InteractionTypeTwo
        /// </summary>
        public class InteractionsList
        {
            private Dictionary<InteractionName, System.Type> interactions = new Dictionary<InteractionName, System.Type>();
            public enum InteractionName {
                DefaultInteraction,
                InteractionTypeOne,
                InteractionTypeTwo
            }
            private InteractionsList() {
                interactions = new Dictionary<InteractionName, System.Type>();
                PopulateDictionary();
            }

            private static InteractionsList _instance;

            private static readonly object _lock = new object(); 

            public static InteractionsList GetInstance() {
                if (_instance == null ){
                    lock (_lock) {
                        if (_instance == null) {
                            _instance = new InteractionsList();
                        }
                    } 
                }
                return _instance;
            }

            private void PopulateDictionary() {
                interactions.Add(InteractionName.DefaultInteraction, typeof(Interaction.Dictionary.DefaultInteraction));
                interactions.Add(InteractionName.InteractionTypeOne, typeof(Interaction.Dictionary.InteractionTypeOne));
                interactions.Add(InteractionName.InteractionTypeTwo, typeof(Interaction.Dictionary.InteractionTypeTwo));
            }

            public System.Type GetTypeFromDictionary(InteractionName interaction) {
                return interactions[interaction];
            }

            public System.Type GetDefaultInteraction() {
                return interactions[InteractionName.DefaultInteraction];
            }
        }
    }
}
