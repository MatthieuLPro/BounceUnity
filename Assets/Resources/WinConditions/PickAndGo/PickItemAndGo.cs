using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemAndGo : WinCondition
{
    [Header("Required number of items to win")]
    [SerializeField]
    private int goalNumber = 0;
    private int numberOfItems = 0;
    private bool inTheZone = false;
    public bool InTheZone { get; set; }

    public void AddItem() {
        numberOfItems += 1;
    }

    public void ResetItem() {
        numberOfItems = 0;
    }

    public override void CheckVictory() {
        if (numberOfItems >= goalNumber && InTheZone) {
            IsWinning = true;
        }
    }
}
