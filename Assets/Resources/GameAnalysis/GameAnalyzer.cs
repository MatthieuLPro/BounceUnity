using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnalyzer : MonoBehaviour
{
    private CharacterForm characterForm;

    private int timeCounter = 0;
    public int TimeCounter { get; set; }
    
    private int timeCounterCircle = 0;
    public int TimeCounterCircle { get; set; }

    private int timeCounterSquare = 0;
    public int TimeCounterSquare { get; set; }

    void Start() {
        characterForm = GameObject.FindGameObjectsWithTag("Form")[0].GetComponent<CharacterForm>();
        InvokeRepeating("UpdateTime", 1f, 1f); 
    }

    private void UpdateTime() {
        TimeCounter += 1;
        if (characterForm.IsCircle()) {
            TimeCounterCircle += 1;
        } else {
            TimeCounterSquare += 1;
        }
    }

    public void ShowAnalysis() {
        Debug.Log("Time : " + TimeCounter.ToString());
        Debug.Log("Time into form circle : " + TimeCounterCircle.ToString());
        Debug.Log("Time into form square : " + TimeCounterSquare.ToString());
    }
}
