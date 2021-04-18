using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalState : MonoBehaviour
{
    public enum States {
        Idle,
        Running,
        Walking
    }

    private States currentState;

    void Start() {
        CurrentState = States.Idle;
    }

    public States CurrentState { get; set; }

    public bool IsIdle() {
        return CurrentState == States.Idle;
    }

    public bool IsRunning() {
        return CurrentState == States.Running;
    }

    public bool IsWalking() {
        return CurrentState == States.Walking;
    }
}
