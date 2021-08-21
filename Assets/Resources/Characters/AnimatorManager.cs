using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [Header("Movement Horizontal direction")]
    [SerializeField]
    private MovementDirection horizontalDirection;

    [Header("Movement Horizontal state")]
    [SerializeField]
    private MovementState horizontalState;

    

    [Header("Vertical state")]
    [SerializeField]
    private VerticalState yState;

    [Header("Climbing state")]
    [SerializeField]
    private Climber.ClimbingAction climbingState;

    [Header("Vertical Movement")]
    [SerializeField]
    private VerticalMoveAction verticalMoveState;
    
    private Animator animator;

#region Unity functions
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateBoolState("isClimbing", climbingState.IsClimbing());
        if (climbingState.IsClimbing()) {
            UpdateBoolState("isClimbingMoving", verticalMoveState.IsMoving);

            UpdateBoolState("isWalking", false);

            UpdateBoolState("isJumping", false);
            UpdateBoolState("isFalling", false);
        } else {
            UpdateBoolState("isClimbingMoving", false);

            UpdateBoolState("isWalking", horizontalState.IsWalking());
            UpdateBoolState("isRunning", horizontalState.IsRunning());

            UpdateBoolState("isJumping", yState.IsJumping());
            UpdateBoolState("isFalling", yState.IsFalling());
        }

        UpdateFloatState("xDirection", horizontalDirection.DirectionToAnimatorFloat());
    }
#endregion
#region Private functions
    private void UpdateBoolState(string stateName, bool newState) {
        animator.SetBool(stateName, newState);
    }

    private void UpdateFloatState(string stateName, float newState) {
        animator.SetFloat(stateName, newState);
    }
#endregion
}
