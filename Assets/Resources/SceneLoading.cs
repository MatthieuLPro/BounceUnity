using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    static public string sceneName;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void Call() {
        if (sceneName != "" || sceneName != null) {
            StartCoroutine(LoadAsyncOperation());
        }
    }

    IEnumerator LoadAsyncOperation() {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForEndOfFrame();
        sceneName = null;
    }
}
