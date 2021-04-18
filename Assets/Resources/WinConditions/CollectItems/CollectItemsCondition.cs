using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemsCondition : WinCondition
{
    [Header("Required number of items to win")]
    [SerializeField]
    private int goalNumber = 0;
    private int numberOfItems = 0;

    public void AddItem() {
        numberOfItems += 1;
    }

    public override void CheckVictory() {
        if (numberOfItems >= goalNumber) {
            IsWinning = true;
        }
    }
}
