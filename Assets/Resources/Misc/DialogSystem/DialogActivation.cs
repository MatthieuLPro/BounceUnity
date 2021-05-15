using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should rename this
public class DialogActivation : MonoBehaviour
{   
    [Header("Activation manager")]
    [SerializeField]
    private ActivationManager activationManager;

    private Dialog dialog;

    void Start() {
        dialog = GetComponent<Dialog>();
    }

#region Unity Functions
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponentInChildren<ActionsManager>().UpdateAuthorizedAction(ActionsManager.Actions.Activate, true);
            activationManager.CurrentType = ActivationManager.Type.Dialog;
            activationManager.UpdateDialog(dialog);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            collider.gameObject.GetComponentInChildren<ActionsManager>().UpdateAuthorizedAction(ActionsManager.Actions.Activate, false);
            activationManager.CurrentType = ActivationManager.Type.None;
            activationManager.UpdateDialog(null);
        }
    }
#endregion
}
