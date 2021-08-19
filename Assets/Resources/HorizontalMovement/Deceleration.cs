using System.Collections;
using System.Collections.Generic;

namespace HorizontalMovement {
    /// <summary>
    ///     Concern : Calculate the new x velocity during deceleration.
    ///     Dependency :
    ///         - HorizontalMovement.Constants 
    /// </summary>
    public class Deceleration
    {
        public float Call(float xVelocity) {
            float newVelocity = xVelocity;

            if (xVelocity > 0) {
                newVelocity =- CalculateVelocityDelta();
                if (newVelocity >= 0) {
                   return NewHorizontalVelocity(newVelocity);
                }
            } else if (xVelocity < 0) {
                newVelocity =+ CalculateVelocityDelta();
                if (newVelocity <= 0) {
                   return NewHorizontalVelocity(newVelocity);
                }
            }
            return ResetHorizontalVelocity();
        }

        private float ResetHorizontalVelocity() {
            return 0f;
        }

        private float NewHorizontalVelocity(float newVelocity) {
            return newVelocity;
        }

        private float CalculateVelocityDelta() {
            return HorizontalMovement.Constants.maxSpeed * HorizontalMovement.Constants.baseDeceleration;
        }
    }
}
