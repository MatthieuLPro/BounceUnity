using System.Collections;

namespace VerticalMovement {
  namespace Gravity {
    /// <summary>
    ///     Concern : Calculate the gravity value depending of vertical velocity.
    ///     Dependency :
    ///         - VerticalMovement.Constants
    /// </summary>
    public static class Calculator
    {
      public static float Call(float yVelocity) {
        if (IsFalling(yVelocity)) {
          return VerticalMovement.Constants.GRAVITY_FALL;
        } else if (IsRising(yVelocity)) {
          return VerticalMovement.Constants.GRAVITY_JUMP;
        } else {
          return VerticalMovement.Constants.GRAVITY_DEFAULT;
        }
      }

      private static bool IsFalling(float yVelocity) {
          return yVelocity < -0.1f;
      }

      private static bool IsRising(float yVelocity) {
          return yVelocity > 0.1f;
      }
    }
  }
}
