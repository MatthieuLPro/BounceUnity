using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MenuOptions
{
    public override void Call() {
        string scenename = "TestMainMenu";
        SceneManager.LoadScene(scenename);
    }
}
