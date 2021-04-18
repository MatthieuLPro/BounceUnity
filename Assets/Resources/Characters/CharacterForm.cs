using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterForm : MonoBehaviour
{
    public enum Forms {
        Circle,
        Square
    }

    public Forms Form;

    void Start() {
        CurrentForm = Forms.Circle;
    }

    public Forms CurrentForm { get; set; }

    public bool IsCircle() {
        return CurrentForm == Forms.Circle;
    }

    public bool IsSquare() {
        return CurrentForm == Forms.Square;
    } 
}
