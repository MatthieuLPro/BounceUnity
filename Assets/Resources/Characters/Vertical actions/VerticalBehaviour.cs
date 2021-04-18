using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBehaviour : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;

    [Header("Character form")]
    [SerializeField]
    private CharacterForm characterForm;

    private Dictionary<CharacterForm.Forms, float> jumpGravityDictionary;
    private Dictionary<CharacterForm.Forms, float> fallGravityDictionary;
    // private VerticalState verticalState;
    private float GRAVITY_DEFAULT = 1.0f;
    private float GRAVITY_FALL_CIRCLE = 25.0f;
    private float GRAVITY_FALL_SQUARE = 25.0f;
    private float GRAVITY_JUMP_CIRCLE = 20.0f;
    private float GRAVITY_JUMP_SQUARE = 20.0f;

#region Unity Functions
    void Start() {
        // verticalState = GetComponent<VerticalState>();
        jumpGravityDictionary = new Dictionary<CharacterForm.Forms, float>();
        jumpGravityDictionary.Add(CharacterForm.Forms.Circle, GRAVITY_JUMP_CIRCLE);
        jumpGravityDictionary.Add(CharacterForm.Forms.Square, GRAVITY_JUMP_SQUARE);
        fallGravityDictionary = new Dictionary<CharacterForm.Forms, float>();
        fallGravityDictionary.Add(CharacterForm.Forms.Circle, GRAVITY_FALL_CIRCLE);
        fallGravityDictionary.Add(CharacterForm.Forms.Square, GRAVITY_FALL_SQUARE);
    }

    void FixedUpdate() {
        if (rb2D.velocity.y < -0.1f) {
            UpdateGravity(fallGravityDictionary[characterForm.CurrentForm]);
        } else if (rb2D.velocity.y > 0.1f) {
            UpdateGravity(jumpGravityDictionary[characterForm.CurrentForm]);
        } else {
            ResetGravity();
            // ResetVerticalVelocity();
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

    // private void ResetVerticalVelocity() {
    //     rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
    // }
#endregion
}
