using System.Collections;

namespace VerticalMovement {
  namespace EarlyFall {
    /// <summary>
    ///     Concern : Calculate the new vertical velocity.
    ///     Dependency :
    ///         - VerticalMovement.Constants
    /// </summary>
    public static class Calculator
    {
      public static float Call(float yVelocity) {
        return yVelocity * VerticalMovement.Constants.velocity_cancel_coefficient;
      }
    }
  }
}
