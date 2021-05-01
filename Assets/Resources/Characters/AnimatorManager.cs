using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    [Header("Horizontal direction")]
    [SerializeField]
    private Horizontal.DirectionState xDirection;

    [Header("Horizontal state")]
    [SerializeField]
    private HorizontalState xState;

    [Header("Vertical state")]
    [SerializeField]
    private VerticalState yState;

    [Header("Catch state")]
    [SerializeField]
    private CatchAction catchState;

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
        UpdateBoolState("isCatching", catchState.IsCatching());
        if (catchState.IsCatching()) {
            UpdateBoolState("isCatchingMoving", verticalMoveState.IsMoving);

            UpdateBoolState("isWalking", false);
            UpdateBoolState("isRunning", false);

            UpdateBoolState("isJumping", false);
            UpdateBoolState("isFalling", false);
        } else {
            UpdateBoolState("isCatchingMoving", false);

            UpdateBoolState("isWalking", xState.IsWalking());
            UpdateBoolState("isRunning", xState.IsRunning());

            UpdateBoolState("isJumping", yState.IsJumping());
            UpdateBoolState("isFalling", yState.IsFalling());
        }

        UpdateFloatState("xDirection", xDirection.DirectionToAnimatorFloat());
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
