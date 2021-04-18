using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class MusicManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField]
    private AudioClip music;

    private bool isLocked;
    public bool IsLocked { get; set; }

    public AudioClip Music {
        get { return music; }
        set { music = value; }
    } 
    
    void Start() {
        EazySoundManager.PlayMusic(Music, 0.25f, true, false, 1, 1);
    }

   public void PlayMusic() {
       if (!IsLocked) {
           EazySoundManager.PlayMusic(Music, 0.25f, true, false, 1, 1);
       }
   }
}
