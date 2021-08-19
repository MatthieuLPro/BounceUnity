using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="HorizontalDirectionState", menuName="ScriptableObjects/HorizontalMovement/MovementDirection", order=1)]
/// <summary>
///     Concern : State machine for horizontal direction.
///     Dependency :
///         - HorizontalMovement.Constants 
/// </summary>
public class MovementDirection : ScriptableObject
{
    public HorizontalMovement.Constants.Directions currentDirection;

    public void UpdateDirection(float xDirection) {
        if(xDirection > 0) {
            currentDirection = HorizontalMovement.Constants.Directions.Right;
        } else if (xDirection < 0) {
            currentDirection = HorizontalMovement.Constants.Directions.Left;
        }
    }

    public float DirectionToFloat() {
        return DirectionAdapters.HorizontalAxisDictionary.Call(currentDirection);
    }

    public float DirectionToAnimatorFloat() {
        return DirectionAdapters.AnimatorDictionary.Call(currentDirection);
    }

    public bool IsLeft() {
        return currentDirection == HorizontalMovement.Constants.Directions.Left;
    }

    public bool IsRight() {
        return currentDirection == HorizontalMovement.Constants.Directions.Right;
    }
}
