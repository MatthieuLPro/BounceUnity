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

    [SerializeField]
    private StaminaData datas;

    private Rigidbody2D rb2d;
    private WallDistance wallDistance;
    private bool isCatching;

    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;

    public enum Direction {
        Right,
        Left,
        None
    };
    private Direction catchingDirection;

    private Stamina.StaminaCore stamina;

#region Unity Functions
    public void Start() {
        rb2d = go.GetComponent<Rigidbody2D>();
        stamina = GetComponent<Stamina.StaminaCore>();
        wallDistance = GetComponent<WallDistance>();
        isCatching = false;
        catchingDirection = Direction.None;
    }
    public void Update() {
        if(isCatching && datas.StaminaIsNotEmpty()) {
            stamina.UpdateConsumingStamina(true);
            stamina.ConsumeStamina(1);
        } else if (!isCatching) {
            stamina.UpdateConsumingStamina(false);
        } else if (datas.StaminaIsEmpty()) {
            stamina.UpdateConsumingStamina(false);
            CancelClimb();
            playerInput.SwitchCurrentActionMap("Gameplay");
        }
    }
#endregion
#region Public Functions

    // Should call specific function depending of the 
    // Movement direction
    public void Call()
    {
        if (horizontalDirectionState.CurrentDirection == Horizontal.DirectionState.Directions.Left && wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.left })) {
            StartClimb(Direction.Left);
        } else if (horizontalDirectionState.CurrentDirection == Horizontal.DirectionState.Directions.Right && wallDistance.CheckContactWithWall(new Vector2[1] { Vector2.right })){
            StartClimb(Direction.Right);
        } else {
            CancelClimb();
        }
    }

    public void Cancel()
    {
        CancelClimb();
    }

    public bool IsCatching() {
        return isCatching;
    }
    public Direction CurrentDirection() {
        return catchingDirection;
    }
#endregion
#region Private Functions
    private void StartClimb(Direction climbDirection) {
        rb2d.velocity = Vector2.zero;
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        isCatching = true;
        catchingDirection = climbDirection;
    }
    private void CancelClimb() {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        isCatching = false;
        catchingDirection = Direction.None;
    }
#endregion
}
