using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool openable = false;
    private bool open = false;
    
#region Functions Unity
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Player" && openable) {
            Open();
            Destroy(gameObject);
        }
    }
#endregion
#region Functions public
    public void Openable() {
        openable = true;
    }

    public void Open() {
        open = true;
    }
#endregion
}
