using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMusic : MonoBehaviour
{
    [Header("Music manager")]
    [SerializeField]
    private GameObject go_musicManager;
    private MusicManager musicManager;

    [Header("Music")]
    [SerializeField]
    private AudioClip music;

    public void Start() {
        musicManager = go_musicManager.GetComponent<MusicManager>();
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            StartMusic();
        }
    }

    public void StopMusic() {
        musicManager.StopMusic();
    }

    public void StartMusic() {
        musicManager.Music = music;
        musicManager.PlayMusic();
    }
}
