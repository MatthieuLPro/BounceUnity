using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VerticalMovement {
    namespace DirectionAdapters {
        /// <summary>
        ///     Concern : Adapts the enum values for the axis Y.
        ///     Dependency :
        ///         - VerticalMovement.Constants
        /// </summary>
        public static class VerticalAxisDictionary
        {
            private const float DownInFloat = -1f;
            private const float TopInFloat = 1f;
            private const float NullInFloat = 0f;
            public static float Call(VerticalMovement.Constants.Direction direction) {
                if(direction == VerticalMovement.Constants.Direction.Down) {
                    return DownInFloat;
                } else if (direction == VerticalMovement.Constants.Direction.Top) {
                    return TopInFloat;
                } else {
                    return NullInFloat;
                }
            }
        }
    }
}
