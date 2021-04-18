using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ItemToCollect : MonoBehaviour
{
    [Header("Win condition")]
    [SerializeField]
    private CollectItemsCondition collectItemsCondition;
    [Header("Collision sound")]
    [SerializeField]
    private AudioClip sound; 

    private void OnCollisionEnter2D(Collision2D collision) {
        EazySoundManager.PlaySound(sound, 2.0f);
        collectItemsCondition.AddItem();
        collectItemsCondition.CheckVictory();
        Destroy(gameObject);
    }
}
