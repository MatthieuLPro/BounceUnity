using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum States {
        in_game,
        win
    }

    [Header("Game Analyzer")]
    [SerializeField]
    private GameAnalyzer gameAnalyzer = null;

    [Header("Checkpoint")]
    [SerializeField]
    private Checkpoint checkpoint;

    private WinCondition winCondition;
    private LooseCondition looseCondition;
    private States currentState;

    void Start() {
        winCondition = GetComponent<WinCondition>();
        looseCondition = GetComponent<LooseCondition>();
        currentState = States.in_game;
    }

    void Update() {
        if (winCondition.IsWinning) {
            WinConsequences();
        } 
        if (looseCondition.IsLoosing) {
            LooseConsequences();
        }
    }

    private void WinConsequences() {
        if (gameAnalyzer != null) {
            gameAnalyzer.ShowAnalysis();
        }
        UnityEditor.EditorApplication.isPaused = true;
    }

    private void LooseConsequences() {
        if (gameAnalyzer != null) {
            gameAnalyzer.ShowAnalysis();
        }
        if (checkpoint.IsActivated) {
            checkpoint.Call();
            looseCondition.IsLoosing = false;
        } else {
            UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
