using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !animator.GetBool(virtualCameraToActivate)) {
            animator.SetBool(virtualCamerasToDesactivate, false);
            animator.SetBool(virtualCameraToActivate, true);
        }
    }
}
