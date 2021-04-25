using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CatchingInputManager : MonoBehaviour
{
    [Header("Action blocker")]
    [SerializeField]
    private ActionBlocker actionBlocker;
    [Header("Catch action")]
    [SerializeField]
    private CatchAction catchScript;
    [Header("Move action")]
    [SerializeField]
    private VerticalMoveAction moveScript;
    private float yDirection;
    [Header("Jump action")]
    [SerializeField]
    private JumpAction jumpScript;
    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;

    private Dictionary<CatchAction.Direction, Vector2> jumpDirection;

#region Functions Unity
    void Start() {
        jumpDirection = new Dictionary<CatchAction.Direction, Vector2>();
        jumpDirection.Add(CatchAction.Direction.Right, new Vector2(-1.0f, 0.5f));
        jumpDirection.Add(CatchAction.Direction.Left, new Vector2(1.0f, 0.5f));
        jumpDirection.Add(CatchAction.Direction.None, Vector2.zero);
    }
    void Update() {
        Move();
    }
#endregion    
#region Functions public
    public void OnCatch(InputAction.CallbackContext context) {
        if (actionBlocker.CatchIsAvailable()) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    catchScript.Cancel();
                    UpdateActionMap("Gameplay");
                }
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (actionBlocker.JumpIsAvailable()) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    Vector2 direction = jumpDirection[catchScript.CurrentDirection()];
                    catchScript.Cancel();
                    jumpScript.CallStartCatching(direction);
                    StartCoroutine(BlockHorizontalMovement());
                    UpdateActionMap("Gameplay");
                }
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        yDirection = context.ReadValue<Vector2>().y;
        
    }
#endregion
#region Functions private
    private IEnumerator BlockHorizontalMovement() {
        actionBlocker.DisableMovement();
        yield return new WaitForSeconds(0.25f);
        actionBlocker.EnableMovement();
    }
    private void CliffJump(CatchAction.Direction xDirection) {
        if (actionBlocker.MovementIsAvailable()) {
            Vector2 yVector = jumpDirection[xDirection];
            catchScript.Cancel();
            jumpScript.CallStartCatchingCliff(yVector);
            StartCoroutine(BlockHorizontalMovement());
            UpdateActionMap("Gameplay");
        }
    }
    private void Move() {
        if (actionBlocker.MovementIsAvailable()) {
            CatchAction.Direction xDirection = catchScript.CurrentDirection();
            if (yDirection != .0f) {
                if (moveScript.IsInCliffEdge(xDirection, yDirection)) {
                    if (yDirection > 0) {
                        CliffJump(xDirection);
                    }
                } else {
                    moveScript.Call(xDirection, yDirection);
                }
            }
        }
    }
    private void UpdateActionMap(string newMap) {
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion    
}
