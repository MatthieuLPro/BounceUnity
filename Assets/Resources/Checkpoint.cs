using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Should finish that
public class Checkpoint : MonoBehaviour
{
    [Header("Lava floor")]
    [SerializeField]
    private GameObject[] lavaFloors;

    [Header("Item to copy")]
    [SerializeField]
    private GameObject prefab;
    public GameObject parent;
    public Vector3 prefabPosition;
    public AudioClip sound;
    public AudioClip musicToActive;

    [Header("Player")]
    [SerializeField]
    private GameObject player;

    [Header("Win condition")]
    [SerializeField]
    private PickItemAndGo pickItemAndGo;

    [Header("Grid movement GO")]
    [SerializeField]
    private GameObject go_gridMovement;

    [Header("Music manager")]
    [SerializeField]
    private MusicManager musicManager;

    [Header("Music")]
    [SerializeField]
    private AudioClip music;

    [Header("Camera gos to desactivate")]
    [SerializeField]
    private GameObject[] camerasToDesactivate;

    [Header("Camera go to activate")]
    [SerializeField]
    private GameObject cameraToActivate;

    private bool isActivated = false;
    public bool IsActivated { get; set; }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            IsActivated = true;
        }
    }

    public void Call() {
        if (IsActivated) {
            ResetGrids();
            ResetMusic();
            ResetPlayerPosition();
            ResetItem();
            ResetCamera();
        }
    }

    private void ResetGrids() {
        foreach (GameObject lavaFloor in lavaFloors)
        {
            lavaFloor.transform.position = Vector3.zero;
            lavaFloor.GetComponent<GridMovement>().DisableMove();
        }
    }

    private void ResetMusic() {
        musicManager.Music = music;
        musicManager.IsLocked = false;
        musicManager.PlayMusic();
    }

    private void ResetPlayerPosition() {
        player.transform.position = transform.position;
    }

    private void ResetItem() {
        GameObject newItem = Instantiate(prefab, prefabPosition, Quaternion.identity);
        List<GridMovement> gridMovements = new List<GridMovement>();
        foreach (GameObject lavaFloor in lavaFloors)
        {
            gridMovements.Add(lavaFloor.GetComponent<GridMovement>());
        }
        newItem.transform.parent = parent.transform;
        newItem.GetComponent<ItemToCollectBis>().SetParams(pickItemAndGo, sound, gridMovements.ToArray(), musicManager, musicToActive);
        pickItemAndGo.ResetItem();
    }

    private void ResetCamera() {
        foreach(GameObject camera in camerasToDesactivate) {
            camera.SetActive(false);
        }
        cameraToActivate.SetActive(true);
    }

}
