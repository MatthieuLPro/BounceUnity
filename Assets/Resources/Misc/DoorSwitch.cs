using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    [Header("New switch sprite")]
    [SerializeField]
    private Sprite activatedSprite;
    public Door[] doors;

    private bool isActivated;
    private SpriteRenderer spriteRenderer;

    private Animator iconAnimator;

#region Functions Unity
    private void Start() {
        isActivated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        iconAnimator = gameObject.GetComponentInChildren<Animator>();
    } 

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player" && !isActivated) {
            foreach (Door door in doors) {
                door.Openable();
            }
            spriteRenderer.sprite = activatedSprite;
            isActivated = true;
            iconAnimator.SetBool("isClose", true);
        }
    }
#endregion
}
