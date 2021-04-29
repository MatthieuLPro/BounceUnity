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
    private float SOUND_VOLUME;
    private float VELOCITY_CANCEL_COEFFICIENT;

    private float[] VERTICAL_THRUSTS;
    private int thrust_index;

    private bool isBuffering;
    private Coroutine tripleJumpCoroutine;
    private float WALL_JUMP_THRUST;
    private float CLIFF_JUMP_THRUST;

#region Unity Functions
    void Awake() {
        stateMachine = GetComponent<VerticalState>();
        groundDistance = GetComponent<GroundDistance>();
        jumpBuffer = GetComponent<JumpBuffer>();

        SOUND_VOLUME = 0.2f;
        VELOCITY_CANCEL_COEFFICIENT = 0.5f;
        VERTICAL_THRUSTS = new float[3] { 4500.0f, 6500.0f, 8500.0f };
        thrust_index = 0;
        isBuffering = false;
        WALL_JUMP_THRUST = 6500.0f;
        CLIFF_JUMP_THRUST = 7500.0f;
    }
#endregion
#region Public Functions
    // Call this function to launch the jump behaviour or to buff a jump
    public void CallStart() {
        if (stateMachine.IsStanding()) {
            // Maybe re-think about this logic
            // Remove DisableVerification when double jump is available
            StartCoroutine(groundDistance.DisableVerification());
            StopTripleJumpBuffer();
            IncreaseJumpVelocity(Vector2.up, VERTICAL_THRUSTS[thrust_index]);
            StartTripleJumpBuffer();
        } else if (stateMachine.IsJumping() || stateMachine.IsFalling()) {
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
            ManageJumpHeight();
            IncreaseJumpVelocity(Vector2.up, VERTICAL_THRUSTS[thrust_index]);
            ResetForJumpBuffer();
        }
    }

    public void CallStartCatching(Vector2 direction) {
        StartCoroutine(groundDistance.DisableVerification());
        StopTripleJumpBuffer();
        IncreaseJumpVelocity(direction, WALL_JUMP_THRUST);
        StartTripleJumpBuffer();
    }

    public void CallStartCatchingCliff(Vector2 direction) {
        Vector2 newDirection = new Vector2(direction.x * -1, direction.y);
        StartCoroutine(groundDistance.DisableVerification());
        StopTripleJumpBuffer();
        IncreaseJumpVelocity(newDirection, CLIFF_JUMP_THRUST);
        StartTripleJumpBuffer();
    }

    // Call this function to launch the early fall behaviour
    public void CallCancel() {
        if (rb2D.velocity.y > 0) DecreaseJumpVelocity();
    }
#endregion
#region Private Functions
    // EARLY FALL = Cancel the jump action
    // It decreases the jump height apex to be more accurate on jump
    private void DecreaseJumpVelocity() {
        rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * VELOCITY_CANCEL_COEFFICIENT);
    }
    
    // JUMP = Start the jump action
    private void IncreaseJumpVelocity(Vector2 direction, float thrust) {
        stateMachine.CurrentState = VerticalState.States.Jumping;
        EazySoundManager.PlaySound(sound, SOUND_VOLUME);
        rb2D.AddForce(direction * thrust);
    }

    // BUFFER = Buff a jump
    private void JumpBuffer() {
        jumpBuffer.SetJumpBuffering();
    }

    private void ManageJumpHeight() {
        thrust_index += 1;
        if (thrust_index > 2) { 
            thrust_index = 2;
        }
    }

    private void StartTripleJumpBuffer() {
        if (!isBuffering) {
            tripleJumpCoroutine = StartCoroutine(ResetTripleJumpBuffer());
        }
    }

    private void StopTripleJumpBuffer() {
        if (isBuffering) {
            StopCoroutine(tripleJumpCoroutine);
            isBuffering = false;
            thrust_index = 0;
        }
    }

    private void ResetForJumpBuffer() {
        StopCoroutine(tripleJumpCoroutine);
        tripleJumpCoroutine = StartCoroutine(ResetTripleJumpBuffer());
    }

    // We reset the triple jump buffer if it is not used
    private IEnumerator ResetTripleJumpBuffer() {
        isBuffering = true;
        yield return new WaitForSeconds(3.5f);
        thrust_index = 0;
        isBuffering = false;
    }
#endregion 
}
