using System.Collections;
using UnityEngine;

namespace VerticalMovement {
  namespace Gravity {
    /// <summary>
    ///     Concern : Update the rigidbody gravity.
    ///     Dependency :
    ///         - VerticalMovement.Gravity.Calculator
    /// </summary>
    public class GravityUpdater : MonoBehaviour
    {
      [Header("Rigidbody")]
      [SerializeField]
      private Rigidbody2D rb2D;

      void FixedUpdate() {
        float newGravity = VerticalMovement.Gravity.Calculator.Call(rb2D.velocity.y);
        if (!NewGravityNotDifferent(newGravity)) {
          UpdateGravity(newGravity);
        }
      }

      private void UpdateGravity(float newGravity) {
          rb2D.gravityScale = newGravity;
      }

      private bool NewGravityNotDifferent(float newGravity) {
        return newGravity == rb2D.gravityScale;
      }
    }
  }
}
