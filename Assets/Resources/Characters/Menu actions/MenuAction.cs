using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAction : MonoBehaviour
{
    private enum States {
        pause,
        unpause
    }

    private States CurrentState;

    [Header("Paused Menu")]
    [SerializeField]
    private GameObject menuCanvas;

    void Start()
    {
        CurrentState = States.unpause;
    }

    public void Call() {
        if (CurrentState == States.unpause) {
            CurrentState = States.pause;
            Time.timeScale = 0;
            menuCanvas.SetActive(true);
        } else {
            CurrentState = States.unpause;
            Time.timeScale = 1;
            menuCanvas.SetActive(false);
        }
    }
}
