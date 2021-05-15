using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [Header("Activation manager")]
    [SerializeField]
    private ActivationManager activationManager;

    private CsDoorOpen openDoor;

    void Start() {
        openDoor = GetComponent<CsDoorOpen>();
    }

#region Functions Unity
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponentInChildren<ActionsManager>().UpdateAuthorizedAction(ActionsManager.Actions.Activate, true);
            activationManager.CurrentType = ActivationManager.Type.OpenDoor;
            activationManager.UpdateOpenDoor(openDoor);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponentInChildren<ActionsManager>().UpdateAuthorizedAction(ActionsManager.Actions.Activate, false);
            activationManager.CurrentType = ActivationManager.Type.None;
            activationManager.UpdateOpenDoor(null);
        }
    }
#endregion
}
