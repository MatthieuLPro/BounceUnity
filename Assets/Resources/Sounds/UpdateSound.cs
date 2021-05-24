using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSound : MonoBehaviour
{
    [Header("Sound manager")]
    [SerializeField]
    private GameObject go_soundManager;
    private SoundManager soundManager;

    [Header("Sound")]
    [SerializeField]
    private AudioClip sound;

    public void Start() {
        soundManager = go_soundManager.GetComponent<SoundManager>();
    }

    public void StartSound() {
        soundManager.Sound = sound;
        soundManager.PlaySound();
    }
}
