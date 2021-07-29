using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MenusInputManager : MonoBehaviour
{
    [Header("Player input")]
    [SerializeField]
    private PlayerInput playerInput;
    [Header("Menu action")]
    [SerializeField]
    private MenuAction menuScript;
    
    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;
    
    [Header("Player inputs mapping")]
    [SerializeField]
    private InputsMapping playerInputsMapping;

#region Functions public
    public void OnMove(InputAction.CallbackContext context) {
        if (context.started) {
            menuManager.UpdateCurrentOptionIndex(context.ReadValue<Vector2>().y);
        }
    }

    public void OnCancel(InputAction.CallbackContext context) {
        if (context.started) {
            menuScript.Call();
            UpdateActionMap("Gameplay");
        }
    }

    public void OnValidation(InputAction.CallbackContext context) {
        if (context.started) {
            menuManager.LaunchOption();
        }
    }
#endregion
#region Functions private
    private void UpdateActionMap(string newMap) {
        playerInputsMapping.UpdateMappingName(newMap);
        playerInput.SwitchCurrentActionMap(newMap);
    }
#endregion 
}
