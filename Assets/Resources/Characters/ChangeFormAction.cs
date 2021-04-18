using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeFormAction : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField]
    private GameObject go;
    [Header("BouncinessBehaviour")]
    [SerializeField]
    private BouncinessBehaviour bounciness;

    [Header("Circle material")]
    [SerializeField]
    private PhysicsMaterial2D circleBounce;
    [Header("Square material")]
    [SerializeField]
    private PhysicsMaterial2D squareBounce;

    [Header("Tilemap collider 2D")]
    [SerializeField]
    private TilemapCollider2D gridCollider;
    [Header("Ice material")]
    [SerializeField]
    private PhysicsMaterial2D iceMaterial;
    [Header("Standard material")]
    [SerializeField]
    private PhysicsMaterial2D standardMaterial;

    private CircleCollider2D collider;
    private SpriteRenderer sprite;
    private CharacterForm characterForm;
    void Awake() {
        characterForm = GetComponent<CharacterForm>();
        collider = go.GetComponent<CircleCollider2D>();
        sprite = go.GetComponent<SpriteRenderer>();
        CircleForm();
    }

    public void Call() {
        if (characterForm.IsCircle()) {
            SquareForm();
        } else if (characterForm.IsSquare()) {
            CircleForm();
        }
    }

    private void CircleForm() {
        collider.sharedMaterial = circleBounce;
        gridCollider.sharedMaterial = iceMaterial;
        sprite.color = Color.green;
        characterForm.CurrentForm = CharacterForm.Forms.Circle;
    }

    private void SquareForm() {
        collider.sharedMaterial = squareBounce;
        gridCollider.sharedMaterial = standardMaterial;
        sprite.color = Color.blue;
        characterForm.CurrentForm = CharacterForm.Forms.Square;
    }
}
