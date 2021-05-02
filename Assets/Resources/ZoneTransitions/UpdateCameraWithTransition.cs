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
            StartCoroutine(TransitionEffectCo());
        }
    }

    private IEnumerator TransitionEffectCo() {
        transitionVirtualCamera.SetActive(true);
        yield return new WaitForSeconds(1f);
        virtualCameraToActivate.SetActive(true);
        transitionVirtualCamera.SetActive(false);
        virtualCameraToDesactivate.SetActive(false);
    }
}
