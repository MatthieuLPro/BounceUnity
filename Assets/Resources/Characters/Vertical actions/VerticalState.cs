using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalState : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;

    [Header("Climber")]
    [SerializeField]
    private Climber.ClimbingAction climber;

    private VerticalMovement.Constants.States previousState;
    private VerticalMovement.Constants.States currentState;
    public VerticalMovement.Constants.States CurrentState { get; set; }

#region Unity Functions
    void Start() {
        CurrentState = VerticalMovement.Constants.States.Standing;
        previousState = CurrentState;
    }

    void FixedUpdate() {
        if (rb2D.velocity.y < -0.1f && !IsFalling() && !climber.IsClimbing()) {
            previousState = CurrentState;
            CurrentState = VerticalMovement.Constants.States.Falling;
        }
    }
#endregion
#region Public Functions
    public bool IsFalling() {
        return CurrentState == VerticalMovement.Constants.States.Falling;
    }

    public bool IsJumping() {
        return CurrentState == VerticalMovement.Constants.States.Jumping;
    }

    public bool IsStanding() {
        return CurrentState == VerticalMovement.Constants.States.Standing;
    }
#endregion
}
