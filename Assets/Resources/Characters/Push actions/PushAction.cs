using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAction : MonoBehaviour
{
    [Header("Movement Horizontal direction")]
    [SerializeField]
    private MovementDirection horizontalDirection;

    private BoxDistance boxDistance;

    private GameObject box;

    private void Start() {
        boxDistance = GetComponent<BoxDistance>();
        box = null;
    }

    public void Call() {
        if (horizontalDirection.IsLeft() && IsInContact(new Vector2[1] { Vector2.left })) {
            Debug.Log("Call on Left");
            box = boxDistance.BoxInContact(new Vector2[1] { Vector2.left });
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxMovement>().isPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
        } else if (horizontalDirection.IsRight() && IsInContact(new Vector2[1] { Vector2.right })){
            Debug.Log("Call on Right");
            box = boxDistance.BoxInContact(new Vector2[1] { Vector2.right });
            box.GetComponent<BoxMovement>().isPushed = true;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = transform.parent.GetComponent<Rigidbody2D>();
        } else {
            Debug.Log("Call False");
        }
    }

    public void Cancel() {
        box.GetComponent<BoxMovement>().isPushed = false;
        box.GetComponent<FixedJoint2D>().enabled = false;
        box.GetComponent<FixedJoint2D>().connectedBody = null;
    }

    private bool IsInContact(Vector2[] directions) {
        return boxDistance.CheckContactWithBox(directions);
    }

}
