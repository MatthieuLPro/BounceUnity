using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fireplace {
    namespace Interaction {
        public class Launcher : MonoBehaviour
        {
            FireActivator fireActivator;
            void Start() {
                fireActivator = new FireActivator();
            }

            public void Call() {
                Debug.Log("Launch fireplace interaction");
                fireActivator.Call();
            }
        }
    }
}
