using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCamera : MonoBehaviour
{
    [Header("Virtual camera to activate")]
    [SerializeField]
    private GameObject virtualCameraToActivate;

    [Header("Virtual camera to desactivate")]
    [SerializeField]
    private GameObject virtualCamerasToDesactivate;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && gameObject != virtualCameraToActivate && !virtualCameraToActivate.activeSelf) {
            virtualCamerasToDesactivate.SetActive(false);
            virtualCameraToActivate.SetActive(true);
        }
    }
}
