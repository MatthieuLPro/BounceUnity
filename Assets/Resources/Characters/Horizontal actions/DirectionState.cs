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
        private Dictionary<Directions, float> directionAnimatorFloat;

        private Directions currentDirection;
        public Directions CurrentDirection { get; set; }

    #region Unity Functions
        void Start() {
            CurrentDirection = Directions.Right;
            InitDictionary();
            InitAnimatorDictionary();
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

        public float DirectionToAnimatorFloat() {
            return directionAnimatorFloat[CurrentDirection];
        }

    #endregion
    #region Private Functions
        private void InitAnimatorDictionary() {
            directionAnimatorFloat = new Dictionary<Directions, float>();
            directionAnimatorFloat.Add(Directions.Left, 0f);
            directionAnimatorFloat.Add(Directions.Right, 1f);
        }
        private void InitDictionary() {
            directionFloat = new Dictionary<Directions, float>();
            directionFloat.Add(Directions.Left, -1f);
            directionFloat.Add(Directions.Right, 1f);
        }
    #endregion
    }
}