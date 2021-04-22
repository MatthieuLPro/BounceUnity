using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBlocker : MonoBehaviour
{

    public bool accelerationAvailable = true;
    public bool catchAvailable = true;
    public bool jumpAvailable = true;
    public bool movementAvailable = true;
    public bool menuAvailable = true;
    public bool smallSizeAvailable = false;

    // Acceleration
    public void EnableAcceleration() {
        accelerationAvailable = true;
    }
    public void DisableAcceleration() {
        accelerationAvailable = false;
    }
    public bool AccelerationIsAvailable() {
        return accelerationAvailable;
    }

    // Catch
    public void EnableCatch() {
        catchAvailable = true;
    }
    public void DisableCatch() {
        catchAvailable = false;
    }
    public bool CatchIsAvailable() {
        return catchAvailable;
    }

    // Jump
    public void EnableJump() {
        jumpAvailable = true;
    }
    public void DisableJump() {
        jumpAvailable = false;
    }
    public bool JumpIsAvailable() {
        return jumpAvailable;
    }

    // Menu
    public void EnableMenu() {
        menuAvailable = true;
    }
    public void DisableMenu() {
        menuAvailable = false;
    }
    public bool MenuIsAvailable() {
        return menuAvailable;
    }

    // Movement
    public void EnableMovement() {
        movementAvailable = true;
    }
    public void DisableMovement() {
        movementAvailable = false;
    }
    public bool MovementIsAvailable() {
        return movementAvailable;
    }

    // SmallSize
    public void EnableSmallSize() {
        smallSizeAvailable = true;
    }
    public void DisableSmallSize() {
        smallSizeAvailable = false;
    }
    public bool SmallSizeIsAvailable() {
        return smallSizeAvailable;
    }
}
