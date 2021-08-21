using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO : This is in climber namespace
public class VerticalMoveAction : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField]
    private Transform transform;

    [Header("Wall distance")]
    [SerializeField]
    private Climber.DistanceChecker wallDistance;

    private VerticalMovement.MovementDirection direction;
    private Dictionary<VerticalMovement.Constants.MovementType, float> movementThrustDictionary;
    private VerticalMovement.Constants.MovementType currentMovementType;

    private bool isMoving;
    public bool IsMoving { get; set; }

#region Unity Functions
    void Start() {
        direction = VerticalMovement.MovementDirection.GetInstance();
        InitializeThrustDictionary();
        currentMovementType = VerticalMovement.Constants.MovementType.Walking;
        isMoving = false;
    }
#endregion
#region Public Functions
    public void Call(float yDirection) {
        direction.UpdateDirection(yDirection);
        Vector3 newVector = new Vector3(.0f, direction.DirectionInFloat() * movementThrustDictionary[currentMovementType], transform.position.z);
        transform.Translate(newVector * Time.deltaTime);
    }

    public bool IsInCliffEdge(Climber.ClimbingAction.Direction xDirection, float yDirection) {
        bool result = true;
        Vector2[] vectorsCollectionCliff = VectorsCollectionCliff(xDirection, yDirection);
        Vector2[] vectorsCollectionTopAndDown = VectorsCollectionTopAndDown(yDirection);
        if (yDirection != 0) {
            if (wallDistance.CheckContactWithWall(vectorsCollectionCliff) && !wallDistance.CheckContactWithWall(vectorsCollectionTopAndDown)) {
                result = false;
            }
        }
        return result;
    }

    public void CallRunning() {
        currentMovementType = VerticalMovement.Constants.MovementType.Running;
    }

    public void CallNotRunning() {
        currentMovementType = VerticalMovement.Constants.MovementType.Walking;
    }
#endregion
#region Private Functions
    private void InitializeThrustDictionary() {
        movementThrustDictionary = new Dictionary<VerticalMovement.Constants.MovementType, float>();
        movementThrustDictionary.Add(VerticalMovement.Constants.MovementType.Running, VerticalMovement.Constants.RUN_THRUST);
        movementThrustDictionary.Add(VerticalMovement.Constants.MovementType.Walking, VerticalMovement.Constants.WALK_THRUST);
    }
    // We need to check if the object is in contact with the cliff 
    private Vector2[] VectorsCollectionCliff(Climber.ClimbingAction.Direction xDirection, float yDirection) {
        return new Vector2[1] { new Vector2(CalculateNewX(xDirection), CalculateNewY(yDirection)) };
    }

    private float CalculateNewX(Climber.ClimbingAction.Direction xDirection) {
        if (xDirection == Climber.ClimbingAction.Direction.Left) {
            return - 1f;
        } else {
            return 1f;
        }
    }

    private float CalculateNewY(float yDirection) {
        if(yDirection > 0) {
            return 0.25f;
        } else {
            return -0.25f;
        }
    }

    // We need to check if the object is in contact with a roof or a floor
    private Vector2[] VectorsCollectionTopAndDown(float yDirection) {
        if (yDirection > 0) {
            return new Vector2[1] { Vector2.up };
        } else {
            return new Vector2[1] { Vector2.down };
        }
    }
#endregion
}
