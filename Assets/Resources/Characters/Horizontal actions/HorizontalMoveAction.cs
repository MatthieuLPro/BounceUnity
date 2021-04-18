using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMoveAction : MonoBehaviour
{
    [Header("Form")]
    [SerializeField]
    private CharacterForm characterForm;

    // Need to remove verticalState because unused
    [Header("Vertical state")]
    [SerializeField]
    private VerticalState verticalState;
    private HorizontalState horizontalState;
    private Rigidbody2D rb2D;

    private float maxAccelerationSpeed = 150f;
    private float baseAccelerationThrust = 0.5f;
    
    private float maxSpeed = 80f;
    private float baseAcceleration = 0.2f;

    private float SpeedAir = 150f;

    private float baseDeceleration = 0.05f;

    private bool isRunning = false;

#region Unity Functions

    void Awake() {
        horizontalState = GetComponent<HorizontalState>();
        rb2D = GetComponent<Rigidbody2D>();
    }

#endregion
#region Public Functions

    public void Call(float direction) {
        Vector2 newDirection = Vector2.zero;
        UpdateHorizontalState(direction != 0);

        if (direction > 0) {
            newDirection = new Vector2(1.0f, .0f);
        } else if (direction < 0) {
            newDirection = new Vector2(-1.0f, .0f);
        }

        if (newDirection == Vector2.zero) {
            Deceleration(newDirection);
        } else {
            Acceleration(newDirection);
        }
    }

    public void CallRunning() {
        isRunning = true;   
    }

    public void CallNotRunning() {
        isRunning = false;
    }
#endregion
#region Private Functions
    private void UpdateHorizontalState(bool isMoving) {
        if (isMoving) {
            if (isRunning) {
                horizontalState.CurrentState = HorizontalState.States.Running;
            } else {
                horizontalState.CurrentState = HorizontalState.States.Walking;
            }
        } else {
            horizontalState.CurrentState = HorizontalState.States.Idle;
        }
    }

    private void Acceleration(Vector2 direction) {
        float xVelocity = rb2D.velocity.x;
        if (direction.x != 0) {
            float currentMaxSpeed = .0f;
            float currentBaseAcceleration = .0f;
            if (horizontalState.IsRunning()) {
                currentMaxSpeed = maxAccelerationSpeed;
                currentBaseAcceleration = baseAccelerationThrust;
            } else {
                currentMaxSpeed = maxSpeed;
                currentBaseAcceleration = baseAcceleration;    
            }
            if (xVelocity >= currentMaxSpeed || xVelocity <= currentMaxSpeed * -1) {
                rb2D.velocity = new Vector2(direction.x * currentMaxSpeed, rb2D.velocity.y);
            } else {
                rb2D.velocity = new Vector2(xVelocity + direction.x * (currentMaxSpeed * currentBaseAcceleration), rb2D.velocity.y);
            }
        }
    }

    private void Deceleration(Vector2 direction) {
        float xVelocity = rb2D.velocity.x;
        float yVelocity = rb2D.velocity.y;
        if (xVelocity > 0) {
            float newVelocity = xVelocity - (maxSpeed * baseDeceleration);
            if (newVelocity < 0) {
                rb2D.velocity = new Vector2(0, yVelocity);
            } else {
                rb2D.velocity = new Vector2(newVelocity, yVelocity);
            }
        } else if (xVelocity < 0) {
            float newVelocity = xVelocity + (maxSpeed * baseDeceleration);
            if (newVelocity > 0) {
                rb2D.velocity = new Vector2(0, yVelocity);
            } else {
                rb2D.velocity = new Vector2(newVelocity, yVelocity);
            }
        }
    }
#endregion
}
