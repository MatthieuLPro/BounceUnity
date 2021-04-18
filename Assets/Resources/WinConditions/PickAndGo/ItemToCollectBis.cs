using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ItemToCollectBis : MonoBehaviour
{
    [Header("Win condition")]
    [SerializeField]
    private PickItemAndGo pickItemAndGo;
    [Header("Collision sound")]
    [SerializeField]
    private AudioClip sound;
    [Header("Grid movement")]
    [SerializeField]
    private GridMovement[] gridMovement;
    [Header("Music manager")]
    [SerializeField]
    private MusicManager musicManager;
    [Header("Music")]
    [SerializeField]
    private AudioClip music;

    public void SetParams(PickItemAndGo pick, AudioClip audio, GridMovement[] grids, MusicManager musicMan, AudioClip mu) {
        pickItemAndGo= pick;
        sound = audio;
        gridMovement = grids;
        musicManager = musicMan;
        music = mu;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        ActivateSounds();
        ActivateItem();
        ActivateGrids();
        Destroy(gameObject);
    }

    private void ActivateSounds() {
        EazySoundManager.PlaySound(sound, 2.0f);
        musicManager.Music = music;
        musicManager.PlayMusic();
        musicManager.IsLocked = true;
    }

    private void ActivateItem() {
        pickItemAndGo.AddItem();
        pickItemAndGo.CheckVictory();
    }

    private void ActivateGrids() {
        foreach (var grid in gridMovement)
        {   
            grid.Call();
        }
    }
}
