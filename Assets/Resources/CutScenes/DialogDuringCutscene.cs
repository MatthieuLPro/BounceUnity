using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogDuringCutscene : MonoBehaviour
{
    public Animator textDisplayAnimator;

    public PlayableDirector currentDirector;

    // Should call a specific input manager
    public GameplayInputManager inputManager;

    public ActionsManager actionsManager;

    public ActivationManager activationManager;

    private Dialog newDialog;

    private bool dialogIsLaunched = false; 

    void Start() {
        newDialog = GetComponent<Dialog>();
    }

    void Update() {
        if (dialogIsLaunched) {
            if (activationManager.ActivationIsFinished()) {
                dialogIsLaunched = false;
                currentDirector.playableGraph.GetRootPlayable(0).SetSpeed(1);
                actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Activate, false);
            }
        }
    }

    public void Call() {
        currentDirector.playableGraph.GetRootPlayable(0).SetSpeed(0);
        activationManager.UpdateDialog(newDialog);
        activationManager.CurrentType = ActivationManager.Type.Dialog;
        actionsManager.UpdateAuthorizedAction(ActionsManager.Actions.Activate, true);
        inputManager.LaunchActivation();
        dialogIsLaunched = true;
    }
}
