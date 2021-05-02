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
    
#region Unity Functions
    void Start()
    {
        InitActionsDictionary();
        InitAuthorizedActions();
        UpdateAllAuthorizedActions(true);
    }
#endregion
#region Public Functions
    public bool ActionIsAvailable(Actions action) {
        return actionsStatement[action];
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

    public void UpdateAuthorizedAction(Actions action, bool newState) {
        actionsStatement[action] = newState;
    }
#endregion
#region Private Functions
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
