using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GameplayInputManager : MonoBehaviour
{
    [Header("Action blocker")]
    [SerializeField]
    private ActionBlocker actionBlocker;

    [Header("Catch action")]
    [SerializeField]
    private CatchAction catchScript;

    [Header("Jump action")]
    [SerializeField]
    private JumpAction jumpScript;

    [Header("Move action")]
    [SerializeField]
    private HorizontalMoveAction moveScript;
    private float moveDirection;

    [Header("Menu action")]
    [SerializeField]
    private MenuAction menuScript;

    [Header("Dash action")]
    [SerializeField]
    private DashAction dashScript;

    [Header("Change size action")]
    [SerializeField]
    private SizeChanger sizeChanger;

    [Header("Change mass action")]
    [SerializeField]
    private MassChanger massChanger;

    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;

    [Header("Animator")]
    [SerializeField]
    private Animator animator;
 
#region Functions Unity
    void Update() {
        Move();
    }
#endregion
#region Functions Public
    public void OnAcceleration(InputAction.CallbackContext context) {
        if (actionBlocker.AccelerationIsAvailable()) {
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
        if (actionBlocker.CatchIsAvailable()) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    catchScript.Call();
                    if (catchScript.IsCatching()) {
                        UpdateActionMap("Catching");
                    }
                }
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context) {
        if (actionBlocker.DashIsAvailable()) {
            if (context.started) {
                if (!dashScript.IsLoading) {
                    dashScript.CallStart();
                    StartCoroutine(BlockActionsDuringDash());
                } 
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (actionBlocker.JumpIsAvailable()) {
            if (context.started) {
                jumpScript.CallStart();
            } else if (context.canceled) {
                jumpScript.CallCancel();
            }
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveDirection = context.ReadValue<Vector2>().x;
    }
    public void Move() {
        if (actionBlocker.MovementIsAvailable()) {
            moveScript.Call(moveDirection);
        }
    }

    public void OnMenu(InputAction.CallbackContext context) {
        if (actionBlocker.MenuIsAvailable()) {
            if (context.started) {
                menuScript.Call();
                UpdateActionMap("Menus");
            }
        }
    }

    public void OnChangeSizeSmall(InputAction.CallbackContext context) {
        if (actionBlocker.SmallSizeIsAvailable()) {
            if (context.started) {
                if (sizeChanger.CurrentSize == SizeChanger.Sizes.Standard) {
                    sizeChanger.Call(SizeChanger.Sizes.Small);
                    massChanger.Call(MassChanger.Masses.Small);
                } else {
                    sizeChanger.Call(SizeChanger.Sizes.Standard);
                    massChanger.Call(MassChanger.Masses.Standard);
                }
            }
        }
    }
#endregion
#region Functions private
    private IEnumerator BlockActionsDuringDash() {
        actionBlocker.DisableMovement();
        actionBlocker.DisableJump();
        yield return new WaitForSeconds(0.25f);
        actionBlocker.EnableMovement();
        actionBlocker.EnableJump();
    }
    private void UpdateActionMap(string newMap) {
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion    
}
