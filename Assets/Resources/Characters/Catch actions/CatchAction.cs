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

    [Header("Horizontal direction")]
    [SerializeField]
    private Horizontal.DirectionState horizontalDirectionState;

    private Rigidbody2D rb2d;
    private WallDistance wallDistance;
    private bool isCatching;

    public enum Direction {
        Right,
        Left,
        None
    };
    private Direction catchingDirection;

    private Stamina stamina;

#region Unity Functions
    public void Start() {
        rb2d = go.GetComponent<Rigidbody2D>();
        stamina = GetComponent<Stamina>();
        wallDistance = GetComponent<WallDistance>();

        isCatching = false;
        catchingDirection = Direction.None;
    }
    public void Update() {
        if(isCatching && !stamina.StaminaIsEmpty()) {
            stamina.UpdateConsumingStamina(true);
            stamina.ConsumeStamina(1);
        } else if (!isCatching) {
            stamina.UpdateConsumingStamina(false);
        } else if (stamina.StaminaIsEmpty()) {
            stamina.UpdateConsumingStamina(false);
            CancelCatch();
        }
    }
#endregion
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
        if (horizontalDirectionState.CurrentDirection == Horizontal.DirectionState.Directions.Left && wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.left })) {
            rb2d.velocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            isCatching = true;
            catchingDirection = Direction.Left;
        } else if (horizontalDirectionState.CurrentDirection == Horizontal.DirectionState.Directions.Right && wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.right })){
            rb2d.velocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            isCatching = true;
            catchingDirection = Direction.Right;
        } else {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
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
