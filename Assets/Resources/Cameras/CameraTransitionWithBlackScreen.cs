using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionWithBlackScreen : MonoBehaviour
{
    [Header("Camera to activate")]
    [SerializeField]
    private string virtualCameraToActivate;

    [Header("Camera to desactivate")]
    [SerializeField]
    private string virtualCamerasToDesactivate;

    [Header("Camera animator")]
    [SerializeField]
    private Animator animator;

    [Header("Transition Manager")]
    [SerializeField]
    private TransitionManager transitionManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !animator.GetBool(virtualCameraToActivate)) {
            StartCoroutine(BlackScreenTransition());
            transitionManager.CallManageActions(collider.gameObject.GetComponentInChildren<ActionsManager>());
        }
    }

    private IEnumerator BlackScreenTransition() {
        animator.SetBool(virtualCamerasToDesactivate, false);
        animator.SetBool(virtualCameraToActivate, true);
        animator.SetBool("trBlackScreen", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("trBlackScreen", false);
    }
}
