using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VerticalMovement {
  namespace EarlyFall {
    /// <summary>
    ///     Concern : Update rigidbody vertical velocity.
    ///     Dependency :
    ///         - VerticalMovement.EarlyFall.Calculator
    /// </summary>
    public class EarlyFallUpdater : MonoBehaviour
    {
        [Header("Rigidbody")]
        [SerializeField]
        private Rigidbody2D rb2D;
        
        public void Call() {
            if (IsRising()) {
              DecreaseJumpVelocity();
            }
        }

        private bool IsRising() {
            return rb2D.velocity.y > 0;
        }

        private void DecreaseJumpVelocity() {
            rb2D.velocity = new Vector2(rb2D.velocity.x, VerticalMovement.EarlyFall.Calculator.Call(rb2D.velocity.y));
        }
    }
  }
}
