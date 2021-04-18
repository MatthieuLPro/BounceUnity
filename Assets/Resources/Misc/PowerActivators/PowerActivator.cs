using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerActivator : MonoBehaviour
{
    public enum Powers {
        SmallSize
    }

    public Powers powerToActivate;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            EnablePower(collider.gameObject.GetComponent<ActionBlocker>());
            Destroy(gameObject);
        }
    }

#region Functions Private
    private void EnablePower(ActionBlocker actionBlocker) {
        switch (powerToActivate)
        {
            case Powers.SmallSize:
                actionBlocker.EnableSmallSize();
                break;
            default:
                Debug.Log("No function is set to enable");
                break;
        }
    }

    private void DisablePower(ActionBlocker actionBlocker) {
        switch (powerToActivate)
        {
            case Powers.SmallSize:
                actionBlocker.DisableSmallSize();
                break;
            default:
                Debug.Log("No function is set to disable");
                break;
        }
    }
#endregion
}
