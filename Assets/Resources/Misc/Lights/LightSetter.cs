using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSetter : MonoBehaviour
{
    [Header("Light to set")]
    [SerializeField]
    private CharacterPointLight lightToSet;

    [Header("Object to follow")]
    [SerializeField]
    private Transform go_transform;

    public void Call()
    {
        lightToSet.enabled = true;
        lightToSet.SetFollower(go_transform);
        lightToSet.SetIntensity(1f);
    }
}
