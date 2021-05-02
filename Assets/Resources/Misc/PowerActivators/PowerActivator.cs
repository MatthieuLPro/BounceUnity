using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerActivator : MonoBehaviour
{
    public ActionsManager.Actions actionToActivate;

#region Unity Functions
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            EnablePower(collider.gameObject.GetComponentInChildren<ActionsManager>());
            Destroy(gameObject);
        }
    }
#endregion
#region Functions Private
    private void EnablePower(ActionsManager actionsManager) {
        actionsManager.AuthorizeNewAction(actionToActivate);
    }
#endregion
}
