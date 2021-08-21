using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    namespace Dictionary {
        public class CoreInteraction : MonoBehaviour
        {
            public string toDisplay;
            public GameObject holder;
            
            public virtual void Call() {
                Debug.Log(toDisplay);
            }
        }
    }
}
