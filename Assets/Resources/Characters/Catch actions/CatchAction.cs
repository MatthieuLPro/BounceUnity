using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CatchAction : MonoBehaviour
{
    [Header("Game object")]
    [SerializeField]
    private GameObject go;
    private Transform transform; 
    private Rigidbody2D rb2d;
    private PlayerInput playerInput;
    private WallDistance wallDistance;
    private bool isCatching;

    public enum Direction {
        Right,
        Left,
        None
    };
    private Direction catchingDirection;

    public void Start() {
        transform = go.GetComponent<Transform>();
        rb2d = go.GetComponent<Rigidbody2D>();
        wallDistance = GetComponent<WallDistance>();
        playerInput = GetComponent<PlayerInput>();

        isCatching = false;
        catchingDirection = Direction.None;
    }

#region Public Functions
    public void Call()
    {
        StartCatch();
    }

    public void Cancel()
    {
        CancelCatch();
    }

    public bool IsCatching() {
        return isCatching;
    }
    public Direction CurrentDirection() {
        return catchingDirection;
    }
#endregion
#region Private Functions
    // Should call specific function depending of the 
    // Movement direction
    private void StartCatch() {
        if (wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.left })) {
            rb2d.velocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            isCatching = true;
            catchingDirection = Direction.Left;
        } else if (wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.right })){
            rb2d.velocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            isCatching = true;
            catchingDirection = Direction.Right;
        } else {
            isCatching = false;
            catchingDirection = Direction.None;
        }
    }

    private void CancelCatch() {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        isCatching = false;
        catchingDirection = Direction.None;
    }
#endregion
}
