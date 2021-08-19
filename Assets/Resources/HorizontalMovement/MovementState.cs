using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="MovementState", menuName="ScriptableObjects/HorizontalMovement/MovementState", order=1)]
/// <summary>
///     Concern : State machine for horizontal movement.
///     Dependency :
///         - HorizontalMovement.Constants 
/// </summary>
public class MovementState : ScriptableObject
{
    public HorizontalMovement.Constants.MovementStates currentState = HorizontalMovement.Constants.MovementStates.Idle;

    public bool IsDeceleration() {
        return currentState == HorizontalMovement.Constants.MovementStates.Decelerating;
    }

    public bool IsIdle() {
        return currentState == HorizontalMovement.Constants.MovementStates.Idle;
    }

    public bool IsRunning() {
        return currentState == HorizontalMovement.Constants.MovementStates.Running;
    }

    public bool IsWalking() {
        return currentState == HorizontalMovement.Constants.MovementStates.Walking;
    }

    public void UpdateHorizontalState(bool isRunning) {
        if (isRunning) {
            currentState = HorizontalMovement.Constants.MovementStates.Running;
        } else {
            currentState = HorizontalMovement.Constants.MovementStates.Walking;
        }
    }

    public void UpdateCurrentState(HorizontalMovement.Constants.MovementStates newState) {
        currentState = newState;
    }
}
