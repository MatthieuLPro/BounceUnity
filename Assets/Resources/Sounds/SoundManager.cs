using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class SoundManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    private AudioClip sound;

    private bool isLocked;
    public bool IsLocked { get; set; }

    public AudioClip Sound {
        get { return sound; }
        set { sound = value; }
    } 

   public void PlaySound() {
        EazySoundManager.PlaySound(Sound, 0.25f);
   }
}
