using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WinCondition : MonoBehaviour
{
    private bool isWinning = false;

    public abstract void CheckVictory();

    public bool IsWinning { get; set; }
}
