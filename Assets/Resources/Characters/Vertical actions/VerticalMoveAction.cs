using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveAction : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField]
    private Transform transform;

    [Header("Wall distance")]
    [SerializeField]
    private WallDistance wallDistance;

    private Vertical.DirectionState directionState;
    private enum MovementType {
        Running,
        Walking
    }
    private Dictionary<MovementType, float> movementThrustDictionary;
    private MovementType currentMovementType;
    private float RUN_THRUST = 50.0f;
    private float WALK_THRUST = 25.0f;

    private bool isMoving;
    public bool IsMoving { get; set; }

#region Unity Functions
    void Start() {
        directionState = GetComponent<Vertical.DirectionState>();
        InitializeThrustDictionary();
        currentMovementType = MovementType.Walking;
        isMoving = false;
    }
#endregion
#region Public Functions
    public void Call(float yDirection) {
        directionState.UpdateDirection(yDirection);
        Vector3 newVector = new Vector3(.0f, directionState.DirectionInFloat() * movementThrustDictionary[currentMovementType], transform.position.z);
        transform.Translate(newVector * Time.deltaTime);
    }

    public bool IsInCliffEdge(Climber.Direction xDirection, float yDirection) {
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
        currentMovementType = MovementType.Running;
    }

    public void CallNotRunning() {
        currentMovementType = MovementType.Walking;
    }
#endregion
#region Private Functions
    private void InitializeThrustDictionary() {
        movementThrustDictionary = new Dictionary<MovementType, float>();
        movementThrustDictionary.Add(MovementType.Running, RUN_THRUST);
        movementThrustDictionary.Add(MovementType.Walking, WALK_THRUST);
    }
    // We need to check if the object is in contact with the cliff 
    private Vector2[] VectorsCollectionCliff(Climber.Direction xDirection, float yDirection) {
        switch (xDirection)
        {
            case Climber.Direction.Left:
                if(yDirection > 0) {
                    return new Vector2[1] { new Vector2(-1f, 0.25f) };
                } else {
                    return new Vector2[1] { new Vector2(-1f, -0.25f) };
                }
                break;
            default:
                if(yDirection > 0) {
                    return new Vector2[1] { new Vector2(1f, 0.25f) };
                } else {
                    return new Vector2[1] { new Vector2(1f, -0.25f) };
                }
                break;
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
