using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalState : MonoBehaviour
{
    public enum States {
        deceleration,
        Idle,
        Running,
        Walking,
    }

    private States currentState;

    void Start() {
        CurrentState = States.Idle;
    }

    public States CurrentState { get; set; }

    public bool IsDeceleration() {
        return CurrentState == States.deceleration;
    }

    public bool IsIdle() {
        return CurrentState == States.Idle;
    }

    public bool IsRunning() {
        return CurrentState == States.Running;
    }

    public bool IsWalking() {
        return CurrentState == States.Walking;
    }

    public void UpdateHorizontalState(bool isMoving, bool hasVelocity, bool isRunning) {
        if (isMoving) {
            if (isRunning) {
                CurrentState = States.Running;
            } else {
                CurrentState = States.Walking;
            }
        } else if(hasVelocity) {
                CurrentState = States.deceleration;
        } else {
            CurrentState = States.Idle;
        }
    }
}
