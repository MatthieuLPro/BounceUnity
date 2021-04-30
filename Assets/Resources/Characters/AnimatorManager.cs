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
    
    private Animator animator;

#region Unity functions
    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateBoolState("isWalking", xState.IsWalking());
        UpdateBoolState("isJumping", yState.IsJumping());
        UpdateBoolState("isFalling", yState.IsFalling());
        
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
