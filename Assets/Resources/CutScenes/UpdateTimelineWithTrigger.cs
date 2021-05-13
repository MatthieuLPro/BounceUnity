using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class UpdateTimelineWithTrigger : MonoBehaviour
{
    private bool isUpdated = false;

    private PlayableDirector newDirector;

    public TimelineManager timelineManager;

    void Start() {
        newDirector = GetComponent<PlayableDirector>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player" && !isUpdated) {
            isUpdated = true;
            timelineManager.UpdateCurrentDirector(newDirector);
            timelineManager.CallWithWait();
        }
    }
}
