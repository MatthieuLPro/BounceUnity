using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ContinueLevel : MenuOptions
{
    [Header("Menu action")]
    [SerializeField]
    private MenuAction menuScript;

    public PlayerInput playerInput;

    public override void Call() {
        menuScript.Call();
        UpdateActionMap();
    }

    private void UpdateActionMap() {
        playerInput.SwitchCurrentActionMap("Gameplay");
    }
}
