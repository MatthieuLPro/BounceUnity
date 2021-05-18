using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizeAction : MonoBehaviour
{
    public ActionsManager actionsManager;
    public ActionsManager.Actions actionToActivate;
    public void Call() {
        actionsManager.AuthorizeNewAction(actionToActivate);
    }
}
