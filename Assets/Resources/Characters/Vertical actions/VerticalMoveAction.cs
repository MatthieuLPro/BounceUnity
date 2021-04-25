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

    private float THRUST = 25.0f;

#region Public Functions
    public void Call(CatchAction.Direction xDirection, float yDirection) {
        Vector2 newDirection = Vector2.zero;
        if (yDirection > 0) {
            newDirection = Vector2.up;
        } else if (yDirection < 0) {
            newDirection = Vector2.down;
        }
        Vector3 newVector = new Vector3(newDirection.x, newDirection.y * THRUST, transform.position.z);
        transform.Translate(newVector * Time.deltaTime);
    }
    public bool IsInCliffEdge(CatchAction.Direction xDirection, float yDirection) {
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
#endregion
#region Private Functions
    // We need to check if the object is in contact with the cliff 
    private Vector2[] VectorsCollectionCliff(CatchAction.Direction xDirection, float yDirection) {
        switch (xDirection)
        {
            case CatchAction.Direction.Left:
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
