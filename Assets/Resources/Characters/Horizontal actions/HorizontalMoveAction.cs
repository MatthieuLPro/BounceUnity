﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HorizontalMoveAction : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField]
    private GameObject go;

    private DirectionState directionState;
    private HorizontalState horizontalState;
    private Rigidbody2D rb2D;

    private float maxAccelerationSpeed = 100f;
    private float baseAccelerationThrust = 0.5f;
    
    private float maxSpeed = 40f;
    private float baseAcceleration = 0.2f;
    private float baseDeceleration = 0.5f;

    private bool isRunning = false;

#region Unity Functions

    void Awake() {
        directionState = GetComponent<DirectionState>();
        horizontalState = GetComponent<HorizontalState>();
        rb2D = go.GetComponent<Rigidbody2D>();
    }

#endregion
#region Public Functions

    public void Call(float direction) {
        Vector2 newDirection = Vector2.zero;
        horizontalState.UpdateHorizontalState(direction != 0, rb2D.velocity.x > 0 || rb2D.velocity.x < 0, isRunning);
        if (direction > 0) {
            newDirection = new Vector2(1.0f, .0f);
        } else if (direction < 0) {
            newDirection = new Vector2(-1.0f, .0f);
        }
        // directionState.UpdateDirection(direction);

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
