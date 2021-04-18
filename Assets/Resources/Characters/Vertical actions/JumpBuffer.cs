using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuffer : MonoBehaviour
{
    public LayerMask groundLayers;
    public Collider2D collider2D;
    private JumpAction jumpAction;

    private float groundDistance;
    private float CIRCLE_DISTANCE_OFFSET = 30f;
    private float SQUARE_DISTANCE_OFFSET = 15f;
    private bool jumpIsBuffered = false;

    private Dictionary<CharacterForm.Forms, float> distanceOffsetDictionary;
    public CharacterForm characterForm;

#region Functions Unity     
    private void Start() {
        distanceOffsetDictionary = new Dictionary<CharacterForm.Forms, float>();
        distanceOffsetDictionary.Add(CharacterForm.Forms.Circle, CIRCLE_DISTANCE_OFFSET);
        distanceOffsetDictionary.Add(CharacterForm.Forms.Square, SQUARE_DISTANCE_OFFSET);
        groundDistance = collider2D.bounds.extents.y + distanceOffsetDictionary[characterForm.CurrentForm];
        jumpAction = GetComponent<JumpAction>();
    }
    private void Update() {
        UpdateCheckDistance();
    }
#endregion
#region Functions Public
    public bool IsBuffered() {
        return jumpIsBuffered;
    }

    public void ResetBuffer() {
        jumpIsBuffered = false;
    }

    public void SetJumpBuffering() {
        List<Ray2D> rays = new List<Ray2D>();
        rays.Add(new Ray2D(transform.position, Vector2.down));
        // rays.Add(new Ray2D(transform.position, new Vector2 (1, -0.5f)));
        // rays.Add(new Ray2D(transform.position, new Vector2 (-1, -0.5f)));
        foreach(Ray2D ray in rays) {
            if (IsGrounded(ray, groundDistance)) {
                jumpIsBuffered = true;
                StartCoroutine(BufferCooldown());
            }
        }
    }
#endregion
#region Functions Private
    private bool IsGrounded(Ray2D ray, float distance) {
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, groundLayers);
        if(hit) {
            // Debug.DrawLine(ray.origin, hit.point, Color.green);
            return true;
        } else {
            // Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            return false;
        }
    }
    // We reset the jump buffer if it is too long to be activated
    private IEnumerator BufferCooldown() {
        yield return new WaitForSeconds(0.25f);
        jumpIsBuffered = false;
    }
    private void UpdateCheckDistance() {
        if (groundDistance != collider2D.bounds.extents.y + distanceOffsetDictionary[characterForm.CurrentForm]) {
            groundDistance = collider2D.bounds.extents.y + distanceOffsetDictionary[characterForm.CurrentForm];
        }
    }
#endregion
}
