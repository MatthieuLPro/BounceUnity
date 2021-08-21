using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class JumpAction : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    [Header("Action sound level 1")]
    [SerializeField]
    private AudioClip soundLevel1;
    [Header("Action sound level 2")]
    [SerializeField]
    private AudioClip soundLevel2;
    [Header("Action sound level 3")]
    [SerializeField]
    private AudioClip soundLevel3;

    private VerticalState stateMachine;
    private GroundDistance groundDistance;
    private JumpBuffer jumpBuffer; 
    private int thrust_index;

    private bool isBuffering;
    private Coroutine tripleJumpCoroutine;
    private AudioClip[] SOUNDS;

#region Unity Functions
    void Awake() {
        stateMachine = GetComponent<VerticalState>();
        groundDistance = GetComponent<GroundDistance>();
        jumpBuffer = GetComponent<JumpBuffer>();

        SOUNDS = new AudioClip[3] { soundLevel1, soundLevel2, soundLevel3 };
        thrust_index = 0;
        isBuffering = false;
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
            IncreaseJumpVelocity(Vector2.up, VerticalMovement.Constants.VERTICAL_THRUSTS[thrust_index]);
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
            IncreaseJumpVelocity(Vector2.up, VerticalMovement.Constants.VERTICAL_THRUSTS[thrust_index]);
            ResetForJumpBuffer();
        }
    }

    public void CallStartCatching(Vector2 direction) {
        StartCoroutine(groundDistance.DisableVerification());
        StopTripleJumpBuffer();
        IncreaseJumpVelocity(direction, VerticalMovement.Constants.WALL_JUMP_THRUST);
        StartTripleJumpBuffer();
    }

    public void CallStartCatchingCliff(Vector2 direction) {
        Vector2 newDirection = new Vector2(direction.x * -1, direction.y);
        StartCoroutine(groundDistance.DisableVerification());
        StopTripleJumpBuffer();
        IncreaseJumpVelocity(newDirection, VerticalMovement.Constants.CLIFF_JUMP_THRUST);
        StartTripleJumpBuffer();
    }

#endregion
#region Private Functions
    
    // JUMP = Start the jump action
    private void IncreaseJumpVelocity(Vector2 direction, float thrust) {
        stateMachine.CurrentState = VerticalMovement.Constants.States.Jumping;
        EazySoundManager.PlaySound(SOUNDS[thrust_index], VerticalMovement.Constants.SOUND_VOLUME);
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
            if (tripleJumpCoroutine != null) {
                StopCoroutine(tripleJumpCoroutine);
            }
            isBuffering = false;
            thrust_index = 0;
        }
    }

    private void ResetForJumpBuffer() {
        if (tripleJumpCoroutine != null) {
            StopCoroutine(tripleJumpCoroutine);
        }
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
