using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HorizontalMovement {
    public class MovementAction : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField]
        private Rigidbody2D rb2D;

        [Header("Movement state")]
        [SerializeField]
        private MovementState currentMovementState;

        [Header("Movement Horizontal direction")]
        [SerializeField]
        private MovementDirection horizontalDirection;

        public bool isRunning = false;

        private HorizontalMovement.Deceleration deceleration;
        private HorizontalMovement.Acceleration acceleration;

        void Awake() {
            deceleration = new HorizontalMovement.Deceleration();
            acceleration = new HorizontalMovement.Acceleration();
        }

        public void Call(float direction) {
            if (PressingADirection(direction)) {
                currentMovementState.UpdateHorizontalState(isRunning);
                horizontalDirection.UpdateDirection(direction);
                SetNewVelocity(acceleration.Call(rb2D.velocity.x, direction, currentMovementState));
            } else {
                if (IsMoving()) {
                    SetNewVelocity(deceleration.Call(rb2D.velocity.x));
                }
                currentMovementState.UpdateCurrentState(HorizontalMovement.Constants.MovementStates.Idle);
            }
        }

        public void CallRunning() {
            isRunning = true;
        }

        public void CallNotRunning() {
            isRunning = false;
        }

        private void SetNewVelocity(float xVelocity) {
            rb2D.velocity = new Vector2(xVelocity, rb2D.velocity.y);
        }

        private bool IsMoving() {
            return rb2D.velocity.x > 0 || rb2D.velocity.x < 0;
        }

        private bool PressingADirection(float direction) {
            return direction != .0f;
        }
    }
}
