using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
#region Public functions
    public void CallManageActions(ActionsManager actionsManager) {
        StartCoroutine(ManageActions(actionsManager));
    }
#endregion
#region Private functions
    private IEnumerator ManageActions(ActionsManager actionsManager) {
        actionsManager.UpdateAllAuthorizedActions(false);
        yield return new WaitForSeconds(1.5f);
        actionsManager.UpdateAllAuthorizedActions(true);
    }
#endregion
}
