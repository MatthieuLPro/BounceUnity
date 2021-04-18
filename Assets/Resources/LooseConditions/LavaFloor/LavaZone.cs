using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaZone : MonoBehaviour
{
    [Header("Loose condition")]
    [SerializeField]
    private LavaFloorCondition LavaFloorCondition;
    
    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Player") {
            LavaFloorCondition.InTheZone = true;
            LavaFloorCondition.CheckDefeat();
        }
    }
}
