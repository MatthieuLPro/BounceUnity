using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPlatform : BasePlatform
{
    public override void OnCollisionEnter2D(Collision2D collision) {
        // GameObject colliderObject = collision.collider.gameObject;
        // if (colliderObject.tag == "Bottom") {
        //     VerticalState currentStateMachine = colliderObject.GetComponent<VerticalState>();
            // if currentStateMachine.CurrentState == VerticalState.States.ReadyToJump
            // Then call jump instead 
        //     currentStateMachine.CurrentState = VerticalState.States.Standing;
        // } else if (colliderObject.tag == "SideLeftBottom" || colliderObject.tag == "SideRightBottom") {
        //     VerticalState currentStateMachine = colliderObject.transform.parent.transform.parent.Find("Bottom").GetComponent<VerticalState>();
        //     currentStateMachine.CurrentState = VerticalState.States.Standing;
        // }
    }
    public override void OnCollisionExit2D(Collision2D collision) {
        // GameObject colliderObject = collision.collider.gameObject;
        // if (colliderObject.tag == "Bottom") {
        //     VerticalState currentStateMachine = colliderObject.GetComponent<VerticalState>();
            /*if (colliderObject.transform.parent.GetComponent<Rigidbody2D>().velocity.y > 5f || colliderObject.transform.parent.GetComponent<Rigidbody2D>().velocity.y < -5f) {
                StartCoroutine(JumpAvailableSequenceCoroutine(currentStateMachine));
            } else {
                currentStateMachine.CurrentState = VerticalState.States.Standing;
            }*/
        //     currentStateMachine.CurrentState = VerticalState.States.Standing;
        // } else if (colliderObject.tag == "SideLeftBottom" || colliderObject.tag == "SideRightBottom") {
        //     VerticalState currentStateMachine = colliderObject.transform.parent.transform.parent.Find("Bottom").GetComponent<VerticalState>();
            /*if (colliderObject.transform.parent.transform.parent.GetComponent<Rigidbody2D>().velocity.y > 5f || colliderObject.transform.parent.transform.parent.GetComponent<Rigidbody2D>().velocity.y < -5f) {
                StartCoroutine(JumpAvailableSequenceCoroutine(currentStateMachine));
            } else {
                currentStateMachine.CurrentState = VerticalState.States.Standing;
            }*/    
        // }
    }
}
