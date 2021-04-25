using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Horizontal {
    public class DirectionState : MonoBehaviour
    {
        public enum Directions {
            Left,
            Right
        }

        private Dictionary<Directions, float> directionFloat;

        private Directions currentDirection;
        public Directions CurrentDirection { get; set; }

    #region Unity Functions
        void Start() {
            CurrentDirection = Directions.Right;
            InitDictionary();
        }
    #endregion
    #region Public Functions
        public void UpdateDirection(float xDirection) {
            if(xDirection > 0) {
                CurrentDirection = Directions.Right;
            } else if (xDirection < 0) {
                CurrentDirection = Directions.Left;
            }
        }

        public float DirectionToFloat() {
            return directionFloat[CurrentDirection];
        }

    #endregion
    #region Private Functions
        private void InitDictionary() {
            directionFloat = new Dictionary<Directions, float>();
            directionFloat.Add(Directions.Left, -1f);
            directionFloat.Add(Directions.Right, 1f);
        }
    #endregion
    }
}