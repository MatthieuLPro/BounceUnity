using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// There are 2 states for each action :
// Authorization => An action is authorized when the character deblock the action
// Availability => An action is available when the character can use it 

// Examples :
// - The jump is authorized and available => The character can do the action (the player can jump in game)
// - The jump is authorized and not available => The character cannot do the action (when a dialog box is open, the player cannot jump)
// - The jump is not authorized and available => IMPOSSIBLE an action cannot be available if not authorized
// - The jump is not authorized and not available => The character cannot do the action (this is the default values)

// We should split this actionsManager into 2 class :
// AvailableActionManager
// AuthorizedActionManager
public class ActionsManager : MonoBehaviour
{
    public enum Actions {
        Acceleration,
        Activate,
        Catch,
        Dash,
        HorizontalMove,
        Jump,
        Menu,
        // ReadText,
        SmallSize
    }

    private List<Actions> authorizedActions;
    private Dictionary<Actions, bool> actionsStatement;
    private Dictionary<Actions, bool> actionToFinish;
    
#region Unity Functions
    void Start()
    {
        InitActionsDictionary();
        InitAuthorizedActions();
        UpdateAuthorizedActions(true);
        actionToFinish = new Dictionary<Actions, bool>();
    }
#endregion
#region Public Functions

    // Only authorized action can be available
    // Should check if the action is in the authorizedActions dico
    public bool ActionIsAvailable(Actions action) {
        return actionsStatement[action];
    }

    // Verify if the action is finish
    public bool ActionIsFinish(Actions action) {
        if (actionToFinish.ContainsKey(action)) {
            return actionToFinish[action];
        } else {
            return true;
        }
    }

    // Only authorized action which are not already in the authorizedActions dico can be authorized
    // Should check if the action is in the authorizedActions dico
    public void AuthorizeNewAction(Actions action) {
        authorizedActions.Add(action);
        UpdateAuthorizedAction(action, true);
    }

    // 1. The action is set at "To be finished"
    // 2. Then we start the waiting (Coroutine)
    // 3. The coroutine sets the action "Finished"
    public void SetDelayToFinishAction(Actions action, float seconds) {
        if (!actionToFinish.ContainsKey(action)) {
            actionToFinish.Add(action, false);
            StartCoroutine(StartWaitingBeforeRemove(seconds, action));
        }
    }

    public void UpdateAuthorizedActions(bool newState) {
        foreach (Actions action in authorizedActions)
        {
            UpdateAuthorizedAction(action, newState);
        }
    }

    // We authorize an action when the action in actionsStatement dico is set to true
    // Should we add authorized action into authorizedActions dico instead ?
    public void UpdateAuthorizedAction(Actions action, bool newState) {
        actionsStatement[action] = newState;
    }
#endregion
#region Private Functions
    // This function remove the finished action
    private IEnumerator StartWaitingBeforeRemove(float seconds, Actions action) {
        yield return new WaitForSeconds(seconds);
        actionToFinish.Remove(action);
    }

    private void InitActionsDictionary() {
        actionsStatement = new Dictionary<Actions, bool>();
        // TODO : Loop on the enum
        actionsStatement.Add(Actions.Acceleration, false);
        actionsStatement.Add(Actions.Activate, false);
        actionsStatement.Add(Actions.Catch, false);
        actionsStatement.Add(Actions.Dash, false);
        actionsStatement.Add(Actions.HorizontalMove, false);
        actionsStatement.Add(Actions.Jump, false);
        actionsStatement.Add(Actions.Menu, false);
        // actionsStatement.Add(Actions.ReadText, false);
        actionsStatement.Add(Actions.SmallSize, false);
    }

    private void InitAuthorizedActions() {
        authorizedActions = new List<Actions>();
        authorizedActions.Add(Actions.Acceleration);
        authorizedActions.Add(Actions.Catch);
        authorizedActions.Add(Actions.HorizontalMove);
        authorizedActions.Add(Actions.Jump);
        authorizedActions.Add(Actions.Menu);
    }
#endregion
}
