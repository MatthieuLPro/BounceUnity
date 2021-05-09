using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLightSetter : MonoBehaviour
{
    [Header("Light to set")]
    [SerializeField]
    private CharacterPointLight lightToSet;

    [Header("Is a adder ?")]
    [SerializeField]
    private bool isAdding = true;

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            if (isAdding) {
                lightToSet.enabled = true;
                lightToSet.SetFollower(collider.transform);
            } else if (lightToSet.enabled) {
                lightToSet.RemoveFollower();
                lightToSet.enabled = false;
            }
        }
    }
}
