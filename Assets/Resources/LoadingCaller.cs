using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCaller : MonoBehaviour
{
    void Start() {
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            if (obj.tag == "Loader") {
                obj.GetComponent<SceneLoading>().Call();
            }
        }
    }
}
