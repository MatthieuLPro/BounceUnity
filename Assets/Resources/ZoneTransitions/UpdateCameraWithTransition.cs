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
        virtualCameraToDesactivate.SetActive(false);
        yield return new WaitForSeconds(1f);
        transitionVirtualCamera.SetActive(false);
        virtualCameraToActivate.SetActive(true);
        CallDisplayPlaceName();
    }

    private void CallDisplayPlaceName() {
        GetComponent<DisplayPlaceName>().DisplayText();
    }
}
