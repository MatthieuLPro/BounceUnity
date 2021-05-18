using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GameplayInputManager : MonoBehaviour
{
    [Header("Catch action")]
    [SerializeField]
    private CatchAction catchScript;

    [Header("Read action")]
    [SerializeField]
    private Dialog dialogScript;

    [Header("Activation manager")]
    [SerializeField]
    private ActivationManager activationManager;

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

    private ActionsManager actionsManager;
 
#region Functions Unity
    void Start() {
        actionsManager = GetComponent<ActionsManager>();
    }

    void FixedUpdate() {
        Move();
    }
#endregion
#region Functions Public
    public void OnAcceleration(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Acceleration)) {
            if (context.interaction is PressInteraction) {
                if (context.started) {
                    moveScript.CallRunning();
                } else if (context.canceled) {
                    moveScript.CallNotRunning();
                }
            }
        } else {
            moveScript.CallNotRunning();
        }
    }

    public void OnActivation(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Activate)) {
            if (context.started) {
                activationManager.Call();
                UpdateActionsForActivation(false);
                if (activationManager.ActivationIsFinished()) {
                    UpdateActionsForActivation(true);
                }
            }
        }
    }

    // Should be in specific input manager
    public void LaunchActivation() {
        activationManager.Call();
        UpdateActionsForActivation(false);
    }

    public void OnCatch(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Catch)) {
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
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Dash)) {
            if (context.started) {
                if (!dashScript.IsLoading) {
                    dashScript.CallStart();
                    StartCoroutine(BlockActionsDuringDash());
                } 
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Jump)) {
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
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.HorizontalMove)) {
            moveScript.Call(moveDirection);
        } else if (actionsManager.ActionIsFinish(ActionsManager.Actions.HorizontalMove)) {
            moveScript.Call(0f);
        }
    }

    public void OnMenu(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Menu)) {
            if (context.started) {
                menuScript.Call();
                UpdateActionMap("Menus");
            }
        }
    }

    public void OnChangeSizeSmall(InputAction.CallbackContext context) {
        if (actionsManager.ActionIsAvailable(ActionsManager.Actions.SmallSize)) {
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
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, false);
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Jump, false);
        yield return new WaitForSeconds(0.25f);
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, true);
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Jump, true);
    }

    private void UpdateActionsForActivation(bool availability) {
        switch(activationManager.CurrentType) {
            case ActivationManager.Type.Dialog:
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Acceleration, availability);
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, availability);
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Jump, availability);
                if (actionsManager.ActionIsAuthorized(ActionsManager.Actions.Catch)) {
                    actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Catch, availability);
                }
                break;
            case ActivationManager.Type.OpenDoor:
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Acceleration, availability);
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Activate, availability);
                if (actionsManager.ActionIsAuthorized(ActionsManager.Actions.Catch)) {
                    actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Catch, availability);
                }
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.HorizontalMove, availability);
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Jump, availability);
                break;
            default:
                break;
        }
    }


    private void UpdateActionMap(string newMap) {
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion    
}
