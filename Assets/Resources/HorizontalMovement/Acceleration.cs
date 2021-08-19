using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorizontalMovement {
    /// <summary>
    ///     Concern : Calculate the new x velocity during the acceleration.
    ///     Dependency :
    ///         - HorizontalMovement.Constants 
    /// </summary>
    public class Acceleration
    {
        public float Call(float xVelocity, float direction, MovementState currentMovementState) {
            float currentMaxSpeed = CalculateMaxSpeed(currentMovementState);
            float currentBaseAcceleration = CalculateBaseAcceleration(currentMovementState);

            if (VelocityExceedLimit(xVelocity, currentMaxSpeed)) {
                return CalculateLimitVelocity(direction, currentMaxSpeed);
            } else {
                return CalculateNewVelocity(xVelocity, direction, currentMaxSpeed, currentBaseAcceleration);
            }
        }

        private float CalculateMaxSpeed(MovementState currentMovementState) {
            if(currentMovementState.IsRunning()) {
                return HorizontalMovement.Constants.maxAccelerationSpeed;
            } else {
                return HorizontalMovement.Constants.maxSpeed;
            }
        } 

        private float CalculateBaseAcceleration(MovementState currentMovementState) {
            if(currentMovementState.IsRunning()) {
                return HorizontalMovement.Constants.baseAccelerationThrust;
            } else {
                return HorizontalMovement.Constants.baseAcceleration;    
            }
        }

        private bool VelocityExceedLimit(float current, float limit) {
            return current >= limit || current <= limit * -1;
        }

        private float CalculateNewVelocity(float current, float direction, float limit, float baseAcceleration) {
            return current + direction * (limit * baseAcceleration);
        }

        private float CalculateLimitVelocity(float direction, float limit) {
            return direction * limit;
        }
    }
}
