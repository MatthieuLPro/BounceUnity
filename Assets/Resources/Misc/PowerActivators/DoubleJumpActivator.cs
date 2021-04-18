using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpActivator : MonoBehaviour
{
    public GroundDistance groundDistance;
    
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            groundDistance.DoubleJumpActivation();
            Destroy(gameObject);
        }
    }
}
