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
    private float moveDirection;
    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;

#region Functions Unity
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

    public void OnMove(InputAction.CallbackContext context) {
        moveDirection = context.ReadValue<Vector2>().y;
    }
#endregion
#region Functions private
    private void UpdateActionMap(string newMap) {
        playerInput.SwitchCurrentActionMap(newMap);
    }

    private void Move() {
        if (actionBlocker.MovementIsAvailable()) {
            moveScript.Call(moveDirection);
        }
    }
#endregion    
}
