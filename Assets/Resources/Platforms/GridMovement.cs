using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    [Header("Movement speed")]
    [SerializeField]
    private float speed;

    private Rigidbody2D rb2D;
    private bool isMoving = false;

    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (isMoving) {
            MoveGrid();
        }
    }

    public void Call() {
        isMoving = true;
    }

    public void DisableMove() {
        isMoving = false;
    }

    private void MoveGrid() {
        Vector3 vectorUp = new Vector3 (0f, 1.0f, 0f);
        rb2D.MovePosition(transform.position + vectorUp * Time.deltaTime * speed);
    }
}
