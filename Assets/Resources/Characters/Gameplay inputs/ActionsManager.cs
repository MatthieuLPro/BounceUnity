using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    public enum Actions {
        Acceleration,
        Catch,
        Dash,
        HorizontalMove,
        Jump,
        Menu,
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
        UpdateAllAuthorizedActions(true);
        actionToFinish = new Dictionary<Actions, bool>();
    }
#endregion
#region Public Functions
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

    public void AuthorizeNewAction(Actions action) {
        authorizedActions.Add(action);
        UpdateAuthorizedAction(action, true);
    }

    public void UpdateAllAuthorizedActions(bool newState) {
        foreach (Actions action in authorizedActions)
        {
            UpdateAuthorizedAction(action, newState);
        }
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
        actionsStatement.Add(Actions.Catch, false);
        actionsStatement.Add(Actions.Dash, false);
        actionsStatement.Add(Actions.HorizontalMove, false);
        actionsStatement.Add(Actions.Jump, false);
        actionsStatement.Add(Actions.Menu, false);
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
