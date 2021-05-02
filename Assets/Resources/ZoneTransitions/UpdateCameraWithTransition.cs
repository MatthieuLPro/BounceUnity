using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UpdateCameraWithTransition : MonoBehaviour
{
    [Header("Virtual camera to activate")]
    [SerializeField]
    private GameObject virtualCameraToActivate;

    [Header("Virtual camera to desactivate")]
    [SerializeField]
    private GameObject virtualCameraToDesactivate;

    [Header("Transition virtual camera")]
    [SerializeField]
    private GameObject transitionVirtualCamera;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && gameObject != virtualCameraToActivate) {
            StartCoroutine(TransitionEffectCo(collider.gameObject.GetComponentInChildren<ActionsManager>()));
        }
    }

    private IEnumerator TransitionEffectCo(ActionsManager actionsManager) {
        transitionVirtualCamera.SetActive(true);
        actionsManager.UpdateAllAuthorizedActions(false);
        yield return new WaitForSeconds(1f);
        virtualCameraToActivate.SetActive(true);
        transitionVirtualCamera.SetActive(false);
        actionsManager.UpdateAllAuthorizedActions(true);
        virtualCameraToDesactivate.SetActive(false);
    }
}
