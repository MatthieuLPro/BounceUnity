using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class MainMenuButtonsManager : MonoBehaviour
{
    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;

    public void OnValidation() {
        menuManager.LaunchOption();
    }

    public void OnMove(InputAction.CallbackContext context) {
        menuManager.UpdateCurrentOptionIndex(context.ReadValue<Vector2>().y);
    }
}
