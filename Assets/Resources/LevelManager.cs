using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public enum States {
        in_game,
        win
    }

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
        SceneManager.LoadScene("TestMainMenu");
        // UnityEditor.EditorApplication.isPaused = true;
    }

    private void LooseConsequences() {
        if (checkpoint.IsActivated) {
            checkpoint.Call();
            looseCondition.IsLoosing = false;
        } else {
            // UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
