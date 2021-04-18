using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;

    public void OnSelect(InputAction.CallbackContext context) {
        if (context.started) {
            menuManager.LaunchOption();
        }
    }

    public void OnMove(InputAction.CallbackContext context) {
        if (context.started) {
            menuManager.UpdateCurrentOptionIndex(context.ReadValue<Vector2>().y);
        }
    }
}
