using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMenuStep : MenuOptions
{
    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;

    [Header("New step")]
    [SerializeField]
    private int newStep;

    public override void Call() {
        menuManager.UpdateStep(newStep);
    }
}
