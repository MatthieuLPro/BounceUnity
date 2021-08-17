using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    /// <summary>
    ///     Concern : Constants list for interaction namespace.
    ///     Usage : Attached to a gameObject with 1 boxCollider and 1 component "Interaction" with 1 nested component "CurrentInteraction"
    /// </summary>
    public static class Constants
    {
        public const string PlayerTag = "Player";
        public const string MainComponentName = "Interaction";
        public const string NestedComponentName = "CurrentInteraction";
        public const string MethodName = "Call";
    }
}