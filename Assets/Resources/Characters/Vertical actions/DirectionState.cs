using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vertical {
    public class DirectionState : MonoBehaviour
    {
        private enum Direction {
            Down,
            Top
        }
        private Direction currentDirection;
        private Dictionary<Direction, float> directionDictionary;

#region Unity Functions
        void Start() {
            InitializeDictionary();
            currentDirection = Direction.Down;
        }
#endregion
#region Public Functions
        public void UpdateDirection(float direction) {
            if (direction > 0) {
                currentDirection = Direction.Top;
            } else if (direction < 0) {
                currentDirection = Direction.Down;
            }
        }
        public float DirectionInFloat() {
            return directionDictionary[currentDirection];
        }
#endregion
#region Private Functions
        private void InitializeDictionary() {
            directionDictionary = new Dictionary<Direction, float>();
            directionDictionary.Add(Direction.Down, -1.0f);
            directionDictionary.Add(Direction.Top, 1.0f);
        }
    }
#endregion
}