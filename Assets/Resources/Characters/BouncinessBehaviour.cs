using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncinessBehaviour : MonoBehaviour
{
    // private Rigidbody2D rb2D;
    // private Vector2 lastVelocity;
    // [Header("Character form")]
    // [SerializeField]
    // private CharacterForm characterForm;

    // void Start() {
    //     rb2D = GetComponent<Rigidbody2D>();
    // }

    // void Update() {
    //     lastVelocity = rb2D.velocity;
    // }

    // private void OnCollisionEnter2D(Collision2D collision) {
    //     if (characterForm.IsCircle()) {
    //         CreateBounce(collision);
    //     }
    // }

    // private void CreateBounce(Collision2D collision) {
    //     float speed = lastVelocity.magnitude;
    //     Vector2 direction = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
    //     rb2D.velocity = direction * Mathf.Max(speed * .75f, .0f);
    // }
}
