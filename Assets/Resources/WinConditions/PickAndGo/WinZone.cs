using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [Header("Win condition")]
    [SerializeField]
    private PickItemAndGo pickItemAndGo;
    
    public void OnCollisionEnter2D(Collision2D collision) {
        pickItemAndGo.InTheZone = true;
        pickItemAndGo.CheckVictory();
    }
    public void OnCollisionExit2D(Collision2D collision) {
        pickItemAndGo.InTheZone = false;
    }
}
