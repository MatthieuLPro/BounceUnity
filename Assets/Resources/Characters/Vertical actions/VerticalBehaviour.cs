using System.Collections;
using UnityEngine;

public class VerticalBehaviour : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    private float GRAVITY_DEFAULT = 1.0f;
    private float GRAVITY_FALL = 25.0f;
    private float GRAVITY_JUMP = 20.0f;

#region Unity Functions
    void FixedUpdate() {
        if (rb2D.velocity.y < -0.1f) {
            UpdateGravity(GRAVITY_FALL);
        } else if (rb2D.velocity.y > 0.1f) {
            UpdateGravity(GRAVITY_JUMP);
        } else {
            ResetGravity();
        }
    }
#endregion
#region Private Functions
    private void UpdateGravity(float newGravity) {
        rb2D.gravityScale = newGravity;
    }

    private void ResetGravity() {
        rb2D.gravityScale = GRAVITY_DEFAULT;
    }
#endregion
}
