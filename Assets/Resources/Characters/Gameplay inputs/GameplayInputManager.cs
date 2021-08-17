using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Events;

public class GameplayInputManager : MonoBehaviour
{
    [Header("Climbing start")]
    [SerializeField]
    private UnityEvent climbingStart;

    [Header("Interaction launcher")]
    [SerializeField]
    private UnityEvent interactionLauncher;

    [Header("Catch box start")]
    [SerializeField]
    private UnityEvent catchBoxStart;
    [Header("Catch box cancel")]
    [SerializeField]
    private UnityEvent catchBoxCancel;

    [Header("Read action")]
    [SerializeField]
    private Dialog dialogScript;

    [Header("Activation manager")]
    [SerializeField]
    private ActivationManager activationManager;

    [Header("Jump start event")]
    [SerializeField]
    private UnityEvent jumpStart;
    [Header("Jump cancel event")]
    [SerializeField]
    private UnityEvent jumpCancel;

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

    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;

    [Header("Animator")]
    [SerializeField]
    private Animator animator;

    private ActionsManager actionsManager;
 
    [Header("Player inputs mapping")]
    [SerializeField]
    private InputsMapping playerInputsMapping;
    

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
        // if (actionsManager.ActionIsAvailable(ActionsManager.Actions.Activate)) {
            if (context.started) {
                interactionLauncher.Invoke();
                // activationManager.Call();
                // UpdateActionsForActivation(false);
                // if (activationManager.ActivationIsFinished()) {
                //     UpdateActionsForActivation(true);
                // }
            }
        // }
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
                    climbingStart.Invoke();
                    // BUG : There is a bug here if the climbing cannot start, we should not 
                    // update the input map
                    UpdateActionMap("Climbing");
                }
            }
        }
    }

    public void OnCatchBox(InputAction.CallbackContext context) {
        if (context.interaction is PressInteraction) {
            if (context.started) {          
                catchBoxStart.Invoke();
            } else if (context.canceled) {        
                catchBoxCancel.Invoke();
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
                jumpStart.Invoke();
            } else if (context.canceled) {
                jumpCancel.Invoke();
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
                UpdateActionMap("Menu");
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
        playerInputsMapping.UpdateMappingName(newMap);
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion    
}
