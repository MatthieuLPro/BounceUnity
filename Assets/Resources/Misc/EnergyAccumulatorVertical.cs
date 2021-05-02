using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

// Is not used, to remove ?
public class EnergyAccumulatorVertical : MonoBehaviour
{
    [Header("Maximum energy")]
    [SerializeField]
    private float maximumEnergy = 10000f;

    [Header("Accumulator sound")]
    [SerializeField]
    private AudioClip sound;

    private float accumulatedEnergy = .0f;
    private bool accumulatorIsTriggered = false;
    private Rigidbody2D rb2D;

    void Update() {
        if (accumulatorIsTriggered) {
            if (Input.GetButton("Jump")) {
                if (accumulatedEnergy < maximumEnergy) {
                    accumulatedEnergy += 50f;
                    EazySoundManager.PlaySound(sound, 0.1f);
                }
            } else {
                rb2D.AddForce(new Vector2(0, 1f) * accumulatedEnergy);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Bottom") {
            rb2D = collider.gameObject.transform.parent.GetComponent<Rigidbody2D>();
            // collider.gameObject.transform.parent.GetComponent<ActionBlocker>().DisableJump();
            accumulatorIsTriggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Bottom") {
            StartCoroutine(ResetCo(collider));
        }
    }

    private IEnumerator ResetCo(Collider2D collider) {
        yield return new WaitForSeconds(0.1f);
        // collider.gameObject.transform.parent.GetComponent<ActionBlocker>().EnableJump();
        rb2D = null;
        accumulatorIsTriggered = false;
        accumulatedEnergy = .0f;
    }
}
