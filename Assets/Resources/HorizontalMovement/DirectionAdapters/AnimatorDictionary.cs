using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionAdapters {
    /// <summary>
    ///     Concern : Adapts the enum values for the animator.
    ///     Dependency :
    ///         - HorizontalMovement.Constants 
    /// </summary>
    public static class AnimatorDictionary
    {
        private const float LeftInFloat = 0f;
        private const float RightInFloat = 1f;
        public static float Call(HorizontalMovement.Constants.Directions direction) {
            if(direction == HorizontalMovement.Constants.Directions.Left) {
                return LeftInFloat;
            } else {
                return RightInFloat;
            }
        }
    }
}

