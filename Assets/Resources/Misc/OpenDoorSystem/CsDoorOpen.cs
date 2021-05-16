using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CsDoorOpen : MonoBehaviour
{
    private bool isActivated;

    [Header("New switch sprite")]
    [SerializeField]
    private Sprite activatedSprite;

    private SpriteRenderer spriteRenderer;

    private Animator iconAnimator;
    
    [Header("Cs to play")]
    [SerializeField]
    private PlayableDirector newDirector;

    public TimelineManager timelineManager;

    private void Start() {
        isActivated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        iconAnimator = gameObject.GetComponentInChildren<Animator>();
    } 

    public void Call() {
        if (!isActivated) {
            spriteRenderer.sprite = activatedSprite;
            iconAnimator.SetBool("isClose", true);
            isActivated = true;
            LaunchDirector();
        }
    }

    private void LaunchDirector() {
        timelineManager.UpdateCurrentDirector(newDirector);
        timelineManager.CallWithBlock(400.0f);
    }
}
