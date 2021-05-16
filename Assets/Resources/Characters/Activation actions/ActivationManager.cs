using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour
{
    public enum Type {
        Dialog,
        None,
        OpenDoor
    }

    // List of the possible activated event
    private Dialog dialog;
    private CsDoorOpen openDoor;

    private Type currentType = Type.None;
    public Type CurrentType { get; set; }

    public void Call() {
        switch(CurrentType) {
            case Type.Dialog:
                dialog.Call();
                break;
            case Type.OpenDoor:
                openDoor.Call();
                break;
            default:
                break; 
        }
    }

    public void UpdateDialog(Dialog newDialog) {
        dialog = newDialog;
    }

    public void UpdateOpenDoor(CsDoorOpen newOpenDoor) {
        openDoor = newOpenDoor;
    }

    public bool ActivationIsFinished() {
        switch(CurrentType) {
            case Type.Dialog:
                return dialog.IsFinished();
            default:
                return false;
        }
    }

}
