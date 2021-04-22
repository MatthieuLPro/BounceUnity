using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class JumpAction : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    [Header("Action sound")]
    [SerializeField]
    private AudioClip sound;

    private VerticalState stateMachine;
    private GroundDistance groundDistance;
    private JumpBuffer jumpBuffer; 
    private float SOUND_VOLUME = 0.2f;
    private float VELOCITY_CANCEL_COEFFICIENT = 0.5f;

    private float[] VERTICAL_THRUSTS = new float[3] { 4500.0f, 6500.0f, 8500.0f };
    private int thrust_index = 0;

    private bool cancelTripleJumpCoroutine = false;

#region Unity Functions
    void Awake() {
        stateMachine = GetComponent<VerticalState>();
        groundDistance = GetComponent<GroundDistance>();
        jumpBuffer = GetComponent<JumpBuffer>();
    }
#endregion
#region Public Functions
    // Call this function to launch the jump behaviour or to buff a jump
    public void CallStart() {
        if (stateMachine.IsStanding()) {
            // Maybe re-think about this logic
            // Remove DisableVerification when double jump is available
            StartCoroutine(groundDistance.DisableVerification());
            IncreaseJumpVelocity();
        } else if (stateMachine.IsJumping()) {
            JumpBuffer();
        }
    }

    // Call this function to launch a buffered jump
    public void CallBuffer() {
        if (stateMachine.IsStanding()) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            // Maybe re-think about this logic
            // Remove DisableVerification when double jump is available
            StartCoroutine(groundDistance.DisableVerification());
            StartCoroutine(ResetTripleJumpBuffer());
            thrust_index += 1;
            if (thrust_index > 2) thrust_index = 0;
            IncreaseJumpVelocity();
        }
    }

    // Call this function to launch the early fall behaviour
    public void CallCancel() {
        if (rb2D.velocity.y > 0) DecreaseJumpVelocity();
    }
#endregion
#region Private Functions
    // BUFFER = Buff a jump
    private void JumpBuffer() {
        jumpBuffer.SetJumpBuffering();
    }

    // EARLY FALL = Cancel the jump action
    // It decreases the jump height apex to be more accurate on jump
    private void DecreaseJumpVelocity() {
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * VELOCITY_CANCEL_COEFFICIENT);
    }
    
    // JUMP = Start the jump action
    private void IncreaseJumpVelocity() {
        stateMachine.CurrentState = VerticalState.States.Jumping;
        EazySoundManager.PlaySound(sound, SOUND_VOLUME);
        rb2D.AddForce(Vector2.up * VERTICAL_THRUSTS[thrust_index]);
    }

    // We reset the triple jump buffer if it is not used
    private IEnumerator ResetTripleJumpBuffer() {
        yield return new WaitForSeconds(1.5f);
        thrust_index = 0;
    }
#endregion 
}
