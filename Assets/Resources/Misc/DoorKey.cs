using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public Door[] doors;
    
#region Functions Unity
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            foreach (Door door in doors) {
                door.Openable();
            }
            Destroy(gameObject);
        }
    }
#endregion
}
