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

    [Header("CatchAction")]
    [SerializeField]
    private CatchAction catchAction;

    private float THRUST = 25.0f;

#region Public Functions
    public void Call(float yDirection) {
        Vector2 newDirection = Vector2.zero;
        Vector2[] vectorsCollection = GetVectorsListFromDirection(yDirection);
        if (yDirection > 0) {
            if (wallDistance.CheckContactWithWall(vectorsCollection)) {
                newDirection = new Vector2(0f, 1.0f);
            } else {
                newDirection = Vector2.zero;
            }
        } else if (yDirection < 0) {
            if (wallDistance.CheckContactWithWall(vectorsCollection)) {
                newDirection = new Vector2(0f, -1.0f);
            } else {
                newDirection = Vector2.zero;
            }
        }
        Vector3 newVector = new Vector3(newDirection.x, newDirection.y * THRUST, transform.position.z);
        transform.Translate(newVector * Time.deltaTime);
    }
#endregion
#region Private Functions
    private Vector2[] GetVectorsListFromDirection(float yDirection) {
        switch (catchAction.CurrentDirection())
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
#endregion
}
