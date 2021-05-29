using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EARLY FALL = Cancel the jump action
// It decreases the jump height apex to be more accurate on jump
public class EarlyFall : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    
    [Header("Cancel velocity coefficient")]
    [SerializeField]
    private float velocity_cancel_coefficient = 0.5f;

    public void Call() {
        if (rb2D.velocity.y > 0) DecreaseJumpVelocity();
    }

    private void DecreaseJumpVelocity() {
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * velocity_cancel_coefficient);
    }
}
