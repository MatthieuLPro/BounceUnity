using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unused
public class RodeoAction : MonoBehaviour
{
    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    [Header("Character form")]
    [SerializeField]
    private CharacterForm characterForm;
    
    private VerticalState stateMachine;
    private float verticalJumpingThrust = 2000.0f;
    private float verticalStandingThrust = 5000.0f;

    void Awake() {
        stateMachine = GetComponent<VerticalState>();
    }

    void FixedUpdate() {
        if (Input.GetButtonDown("Down")) {
            if (stateMachine.IsStanding()) {
                ApplyVerticalThrust(new Vector2(0, -1.0f), verticalStandingThrust);
            }
        }
    }

    void ApplyVerticalThrust(Vector2 direction, float thrust) {
        rb2D.AddForce(direction * thrust);
    }
}
