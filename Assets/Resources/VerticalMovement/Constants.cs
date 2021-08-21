using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VerticalMovement {
    /// <summary>
    ///     Concern : Constants list for vertical movement namespace.
    /// </summary>
    public static class Constants
    {
      public const float GRAVITY_DEFAULT = 1.0f;
      public const float GRAVITY_FALL = 25.0f;
      public const float GRAVITY_JUMP = 20.0f;
      public const float velocity_cancel_coefficient = 0.5f;
      public enum Direction {
            Down,
            Top
        }
      public const float SOUND_VOLUME = 0.2f;
      public static readonly float[] VERTICAL_THRUSTS = new float[3] { 4500.0f, 6500.0f, 8500.0f };
      public const float WALL_JUMP_THRUST = 6500.0f;
      public const float CLIFF_JUMP_THRUST = 7500.0f;
      public const float SQUARE_DISTANCE_OFFSET = 15f;
      public const float RUN_THRUST = 50.0f;
      public const float WALK_THRUST = 25.0f;

      public enum States {
          Falling,
          Jumping,
          Standing
      }

      public enum MovementType {
        Running,
        Walking
    }
    }
}
