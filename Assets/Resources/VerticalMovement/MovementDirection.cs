using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VerticalMovement {
    /// <summary>
    ///     Concern : Update vertical movement state : direction rising or falling.
    ///     Dependency :
    ///         - VerticalMovement.Constants
    ///         - VerticalMovement.DirectionAdapters.VerticalAxisDictionary
    /// </summary>
    public class MovementDirection
    {
        private VerticalMovement.Constants.Direction currentDirection;

        private MovementDirection() {
            currentDirection = VerticalMovement.Constants.Direction.Down;
        }

        private static MovementDirection _instance;

        private static readonly object _lock = new object(); 

        public static MovementDirection GetInstance() {
            if (_instance == null ){
                lock (_lock) {
                    if (_instance == null) {
                        _instance = new MovementDirection();
                    }
                } 
            }
            return _instance;
        }

        public void UpdateDirection(float direction) {
            if (IsRight(direction)) {
                currentDirection = VerticalMovement.Constants.Direction.Top;
            } else if (IsLeft(direction)) {
                currentDirection = VerticalMovement.Constants.Direction.Down;
            }
        }

        private bool IsRight(float direction) {
            return direction > 0;
        }

        private bool IsLeft(float direction) {
            return direction < 0;
        }

        public float DirectionInFloat() {
            return VerticalMovement.DirectionAdapters.VerticalAxisDictionary.Call(currentDirection);
        }
    }
}