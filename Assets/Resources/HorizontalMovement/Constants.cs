using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorizontalMovement {
    /// <summary>
    ///     Concern : Constants list for horizontal movement namespace.
    /// </summary>
    public static class Constants
    {
        public enum Directions {
            Left,
            Right
        }

        public enum MovementStates {
            Decelerating,
            Idle,
            Running,
            Walking,
        }

        public const float maxAccelerationSpeed = 100f;
        public const float baseAccelerationThrust = 0.5f;
        
        public const float maxSpeed = 40f;
        public const float baseAcceleration = 0.2f;
        public const float baseDeceleration = 0.5f;
    }
}
