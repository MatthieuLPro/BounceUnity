using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        public class InteractionCore : MonoBehaviour
        {
            public string toDisplay;
            
            public void Call() {
                Debug.Log(toDisplay);
            }
        }
    }
}
