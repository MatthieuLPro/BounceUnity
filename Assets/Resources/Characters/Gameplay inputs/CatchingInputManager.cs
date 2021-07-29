using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CatchingInputManager : MonoBehaviour
{
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

    private ActionsManager actionsManager;

    private Dictionary<CatchAction.Direction, Vector2> jumpDirection;

    [Header("Player inputs mapping")]
    [SerializeField]
    private InputsMapping playerInputsMapping;

#region Functions Unity
    void Start() {
        actionsManager = GetComponent<ActionsManager>();

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
    public void OnAcceleration(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Acceleration)) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    moveScript.CallRunning();
                } else if (context.canceled) {
                    moveScript.CallNotRunning();
                }
            }
        }
    }

    public void OnCatch(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Catch)) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    catchScript.Cancel();
                    UpdateActionMap("Gameplay");
                }
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Jump)) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    Vector2 direction = jumpDirection[catchScript.CurrentDirection()];
                    catchScript.Cancel();
                    jumpScript.CallStartCatching(direction);
                    StartCoroutine(BlockHorizontalMovement());
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
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, false);
        actionsManager.SetDelayToFinishAction(ActionsManager.Actions.HorizontalMove, 2.0f);
        yield return new WaitForSeconds(0.25f);
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, true);
        UpdateActionMap("Gameplay");
    }
    private void CliffJump(CatchAction.Direction xDirection) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.HorizontalMove)) {
            Vector2 yVector = jumpDirection[xDirection];
            catchScript.Cancel();
            jumpScript.CallStartCatchingCliff(yVector);
            StartCoroutine(BlockHorizontalMovement());
        }
    }
    private void Move() {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.HorizontalMove)) {
            CatchAction.Direction xDirection = catchScript.CurrentDirection();
            if (yDirection != .0f) {
                if (moveScript.IsInCliffEdge(xDirection, yDirection)) {
                    if (yDirection > 0) {
                        CliffJump(xDirection);
                    }
                } else {
                    moveScript.IsMoving = true;
                    moveScript.Call(yDirection);
                }
            } else {
                moveScript.IsMoving = false;
            }
        }
    }
    private void UpdateActionMap(string newMap) {
        playerInputsMapping.UpdateMappingName(newMap);
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion    
}
