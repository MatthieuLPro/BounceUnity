using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lizard {
  namespace Interaction {
    /// <summary>
    ///     Concern : Launch the animation "eat the lizard"
    ///     Usage : Call by the specific interaction
    ///     Dependency : 
    ///         - ???
    /// </summary>
    public class Animation
    {
        public void Call() {
            Debug.Log("Do an animation");
        }
    }
  }
}
