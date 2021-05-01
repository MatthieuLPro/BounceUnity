using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalState : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;

    [Header("CatchAction")]
    [SerializeField]
    private CatchAction catchAction;

    public enum States {
        Falling,
        Jumping,
        Standing
    }

    private States previousState;
    private States currentState;
    public States CurrentState { get; set; }

#region Unity Functions
    void Start() {
        CurrentState = States.Standing;
        previousState = CurrentState;
    }

    void FixedUpdate() {
        if (rb2D.velocity.y < -0.1f && !IsFalling() && !catchAction.IsCatching()) {
            previousState = CurrentState;
            CurrentState = VerticalState.States.Falling;
        }
    }
#endregion
#region Public Functions
    public bool IsFalling() {
        return CurrentState == States.Falling;
    }

    public bool IsJumping() {
        return CurrentState == States.Jumping;
    }

    public bool IsStanding() {
        return CurrentState == States.Standing;
    }
#endregion
}
