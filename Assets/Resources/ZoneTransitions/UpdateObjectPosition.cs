using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObjectPosition : MonoBehaviour
{
    [Header("New character position")]
    [SerializeField]
    private Vector3 newPosition;

    private bool isTeleported;

    void Start() {
        isTeleported = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !isTeleported) {
            StartCoroutine(UpdatePositionCo(collider.gameObject));
        }
    }

    private IEnumerator UpdatePositionCo(GameObject goToMove) {
        isTeleported = true;
        yield return new WaitForSeconds(0.9f);
        UpdatePosition(goToMove);
        isTeleported = false;
    }

    public void UpdatePosition(GameObject goToMove) {
        goToMove.transform.position = newPosition;
    }
}
