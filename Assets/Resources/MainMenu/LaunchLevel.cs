using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchLevel : MenuOptions
{
    [Header("Scene name")]
    [SerializeField]
    private string sceneName;

    [Header("Scene loader")]
    [SerializeField]
    private SceneLoading sceneLoading;

    public override void Call() {
        SceneLoading.sceneName = sceneName;
        SceneManager.LoadScene("TestLoading");
    }
}
