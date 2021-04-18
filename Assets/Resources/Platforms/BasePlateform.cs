using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlatform : MonoBehaviour
{
    public abstract void OnCollisionEnter2D(Collision2D collision);
    public abstract void OnCollisionExit2D(Collision2D collision);

    public void OnCollisionStay2D(Collision2D collision) {
        /*GameObject colliderObject = collision.collider.gameObject;
        if (colliderObject.tag == "Bottom") {
            VerticalState currentStateMachine = colliderObject.GetComponent<VerticalState>();
            currentStateMachine.CurrentState = VerticalState.States.Standing;
        } else if (colliderObject.tag == "SideLeftBottom" || colliderObject.tag == "SideRightBottom") {
            VerticalState currentStateMachine = colliderObject.transform.parent.transform.parent.Find("Bottom").GetComponent<VerticalState>();
            currentStateMachine.CurrentState = VerticalState.States.Standing;
        }*/
    }

    // public IEnumerator JumpAvailableSequenceCoroutine(VerticalState currentStateMachine) {
        /*yield return new WaitForSeconds(0.25f);
        currentStateMachine.CurrentState = VerticalState.States.Jumping;*/
    // }
}
