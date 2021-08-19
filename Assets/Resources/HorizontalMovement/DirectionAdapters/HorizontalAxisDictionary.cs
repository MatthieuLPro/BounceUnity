using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DirectionAdapters {
    /// <summary>
    ///     Concern : Adapts the enum values for the axis X.
    ///     Dependency :
    ///         - HorizontalMovement.Constants 
    /// </summary>
    public class HorizontalAxisDictionary : MonoBehaviour
    {
        private const float LeftInFloat = -1f;
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