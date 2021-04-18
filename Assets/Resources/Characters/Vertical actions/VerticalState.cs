using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalState : MonoBehaviour
{
    // Falling is used?
    public enum States {
        Falling,
        Jumping,
        Standing
    }

    private States currentState;

    void Start() {
        CurrentState = States.Standing;
    }

    public States CurrentState { get; set; }

    public bool IsFalling() {
        return CurrentState == States.Falling;
    }

    public bool IsJumping() {
        return CurrentState == States.Jumping;
    }

    public bool IsStanding() {
        return CurrentState == States.Standing;
    }
}
