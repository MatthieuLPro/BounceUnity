using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [Header("Current playable director")]
    [SerializeField]
    private PlayableDirector currentDirector;

    [Header("Play on awake ?")]
    [SerializeField]
    private bool playOnAwake = false;

    [Header("Transition Manager")]
    [SerializeField]
    private TransitionManager transitionManager;

    [Header("Actions Manager")]
    [SerializeField]
    private ActionsManager actionsManager;

    private PlayState previousState;

    void Start() {
        if (playOnAwake) {
            transitionManager.UpdateManageActions(actionsManager, false);
            currentDirector.Play();
        }
    }

    void Update() {
        if (currentDirector.state == PlayState.Playing && previousState != currentDirector.state) {
            previousState = currentDirector.state;
        } else if (currentDirector.state == PlayState.Paused && previousState != currentDirector.state) {
            previousState = currentDirector.state;
            transitionManager.UpdateManageActions(actionsManager, true);
        }
    }

    public void Call() {
        transitionManager.UpdateManageActions(actionsManager, false);
        currentDirector.Play();
    }

    public void CallWithBlock(float waitTime) {
        StartCoroutine(BlockAction(waitTime));
        currentDirector.Play();
    }

    public void CallWithWait() {
        transitionManager.UpdateManageActions(actionsManager, false);
        StartCoroutine(WaitBeforeLaunchCs());
    }

    public void UpdateCurrentDirector(PlayableDirector newDirector) {
        currentDirector = newDirector;
    }

    public IEnumerator WaitBeforeLaunchCs() {
        yield return new WaitForSeconds(2f);
        currentDirector.Play();
    }

    public IEnumerator BlockAction(float time) {
        transitionManager.UpdateManageActions(actionsManager, false);
        yield return new WaitForSeconds(time);
        transitionManager.UpdateManageActions(actionsManager, true);
    }
}
