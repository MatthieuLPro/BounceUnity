using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsDoorOpen : MonoBehaviour
{
    [Header("Cut scene camera")]
    [SerializeField]
    private string cutSceneCamera;

    [Header("Original camera")]
    [SerializeField]
    private string originalCamera;

    [Header("Camera animator")]
    [SerializeField]
    private Animator animator;

    [Header("Transition Manager")]
    [SerializeField]
    private TransitionManager transitionManager;

    [Header("Door")]
    [SerializeField]
    private GameObject door;

    private bool isActivated;

    [Header("New switch sprite")]
    [SerializeField]
    private Sprite activatedSprite;
    public Door[] doors;

    private SpriteRenderer spriteRenderer;

    private Animator iconAnimator;

    private void Start() {
        isActivated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        iconAnimator = gameObject.GetComponentInChildren<Animator>();
    } 

    public void Call() {
        if (!isActivated) {
            StartCoroutine(BlackScreenTransition());
            foreach (Door door in doors) {
                door.Openable();
            }
            spriteRenderer.sprite = activatedSprite;
            iconAnimator.SetBool("isClose", true);
            isActivated = true;
        }
    }

    private IEnumerator BlackScreenTransition() {
        animator.SetBool(originalCamera, false);
        animator.SetBool(cutSceneCamera, true);
        animator.SetBool("trBlackScreen", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("trBlackScreen", false);

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(OpenTheDoor());
        yield return new WaitForSeconds(5f);

        animator.SetBool(cutSceneCamera, false);
        animator.SetBool(originalCamera, true);
        animator.SetBool("trBlackScreen", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("trBlackScreen", false);
    }

    // Fair enough
    private IEnumerator OpenTheDoor() {
        while(door.transform.position.y > 95f) {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y - 0.25f, door.transform.position.z);
        yield return new WaitForSeconds(0.0005f);
        }
    }
}
