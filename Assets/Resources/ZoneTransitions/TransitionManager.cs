using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should be rename into action blocker manager ?
// Shoule be move into manage actions class ?
public class TransitionManager : MonoBehaviour
{
#region Public functions
    public void CallManageActions(ActionsManager actionsManager) {
        StartCoroutine(ManageActions(actionsManager));
    }

    public void UpdateManageActions(ActionsManager actionsManager, bool authorization) {
        actionsManager.UpdateAuthorizedActions(authorization);
    }
#endregion
#region Private functions
    private IEnumerator ManageActions(ActionsManager actionsManager) {
        actionsManager.UpdateAuthorizedActions(false);
        yield return new WaitForSeconds(1.5f);
        actionsManager.UpdateAuthorizedActions(true);
    }
#endregion
}
