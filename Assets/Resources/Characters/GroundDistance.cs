using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDistance : MonoBehaviour
{
    [Header("Dust effect")]
    [SerializeField]
    private DustEffect dust;
    public LayerMask groundLayers;
    public PolygonCollider2D collider;
    private JumpAction jumpAction;
    private JumpBuffer jumpBuffer;

    private float groundDistance;
    private float GROUND_DISTANCE_OFFSET = 3f;
    private VerticalState state;
    private bool isEnable = true;
    private bool jumpIsBuffered = false;
    private bool doubleJumpPower = false; 
    public SizeChanger sizeChanger;

#region Functions Unity     
    private void Start() {
        groundDistance = collider.bounds.extents.y + GROUND_DISTANCE_OFFSET;
        state = GetComponent<VerticalState>();
        jumpAction = GetComponent<JumpAction>();
        jumpBuffer = GetComponent<JumpBuffer>();
    }

    private void FixedUpdate() {
        if (isEnable) {
            UpdateCheckDistance();
            if (CheckGrounded()) {
                if (state.CurrentState != VerticalState.States.Standing) {
                    state.CurrentState = VerticalState.States.Standing;
                    dust.Call();
                }
                if (jumpBuffer.IsBuffered()) {
                    jumpAction.CallBuffer();
                    jumpBuffer.ResetBuffer();
                }
            }
        }
    }
#endregion
#region Functions Public
    public IEnumerator DisableVerification() {
        isEnable = false;
        yield return new WaitForSeconds(0.5f);
        isEnable = true;
    }

    public void UpdateCheckDistance() {
        if (groundDistance != collider.bounds.extents.y + GROUND_DISTANCE_OFFSET) {
            groundDistance = collider.bounds.extents.y + GROUND_DISTANCE_OFFSET;
        }
    }

    public void DoubleJumpActivation() {
        doubleJumpPower = true;
    }
#endregion
#region Functions Private
    private bool CheckGrounded() {
        float min_angle = 0;
        bool isGrounded = false;
        List<Ray2D> rays = new List<Ray2D>();
        rays.Add(new Ray2D(transform.position, Vector2.down));

        // Without wall jump
        if (doubleJumpPower) {
            min_angle = -0.25f;
            if (sizeChanger.CurrentSize == SizeChanger.Sizes.Small) {
                min_angle = -0.75f;
            }
        } else {
            min_angle = -0.95f;
            if (sizeChanger.CurrentSize == SizeChanger.Sizes.Small) {
                min_angle = -1.45f;
            }
        }

        for(float i = min_angle; i > -10.0f; i -= 0.25f) {
            rays.Add(new Ray2D(transform.position, new Vector2 (1, i)));
            rays.Add(new Ray2D(transform.position, new Vector2 (-1, i)));
        }

        foreach(Ray2D ray in rays) {
            if (IsGrounded(ray, groundDistance)) {
                isGrounded = true;
            }
        }
        return isGrounded;
    }

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
#endregion
}
