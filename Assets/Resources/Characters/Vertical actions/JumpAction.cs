using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class JumpAction : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    
    [Header("Character form")]
    [SerializeField]
    private CharacterForm characterForm;

    [Header("Action sound")]
    [SerializeField]
    private AudioClip sound;

    private Dictionary<CharacterForm.Forms, float> thrustDictionary;
    private VerticalState stateMachine;
    private GroundDistance groundDistance;
    private JumpBuffer jumpBuffer; 
    private float MAXIMUM_VERTICAL_VELOCITY = 200.0f;
    private float SOUND_VOLUME = 2.0f;
    private float VELOCITY_CANCEL_COEFFICIENT = 0.5f;
    private float VERTICAL_THRUST_CIRCLE = 6500.0f;
    private float VERTICAL_THRUST_SQUARE = 4500.0f;
    private float CIRCLE_BUFFER_INCREASE = 50.0f;

#region Unity Functions
    void Awake() {
        stateMachine = GetComponent<VerticalState>();
        groundDistance = GetComponent<GroundDistance>();
        jumpBuffer = GetComponent<JumpBuffer>();
        thrustDictionary = new Dictionary<CharacterForm.Forms, float>();
        thrustDictionary.Add(CharacterForm.Forms.Circle, VERTICAL_THRUST_CIRCLE);
        thrustDictionary.Add(CharacterForm.Forms.Square, VERTICAL_THRUST_SQUARE);
    }
#endregion
#region Public Functions
    // Call this function to launch the jump behaviour or the buffer checker
    public void CallStart() {
        if (stateMachine.IsStanding()) {
            // Remove DisableVerification when double jump is available
            StartCoroutine(groundDistance.DisableVerification());
            IncreaseJumpVelocity();
        } else if (stateMachine.IsJumping()) {
            jumpBuffer.SetJumpBuffering();
        }
    }

    public void CallBuffer() {
        if (stateMachine.IsStanding()) {
            if (characterForm.IsSquare()) {
                rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            } else if (characterForm.IsCircle()) {
                rb2D.velocity = new Vector2(rb2D.velocity.x, CIRCLE_BUFFER_INCREASE);
            }
            // Remove DisableVerification when double jump is available
            StartCoroutine(groundDistance.DisableVerification());
            IncreaseJumpVelocity();
        }
    }

    // Call this function to launch the early fall behaviour
    public void CallCancel() {
        // Why there is the IsStanding verification ?
        // if (stateMachine.IsStanding()) {
        if (rb2D.velocity.y > 0) {    
            DecreaseJumpVelocity();
        }
        // }
    }
#endregion
#region Private Functions
    // Start the jump action => Adding a strength on Y+
    private void IncreaseJumpVelocity() {
        stateMachine.CurrentState = VerticalState.States.Jumping;
        EazySoundManager.PlaySound(sound, SOUND_VOLUME);
        if (rb2D.velocity.y < MAXIMUM_VERTICAL_VELOCITY) {
            rb2D.AddForce(Vector2.up * thrustDictionary[characterForm.CurrentForm]);
        }
    }

    // EARLY FALL
    // Cancel the jump action => Cutting the Y velocity by 2
    // It decreases the jump height apex to be more accurate on jump
    private void DecreaseJumpVelocity() {
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * VELOCITY_CANCEL_COEFFICIENT);
    }
#endregion 
}
