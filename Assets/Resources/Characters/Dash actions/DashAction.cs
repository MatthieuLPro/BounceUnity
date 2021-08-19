using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAction : MonoBehaviour
{
    [Header("Movement Horizontal direction")]
    [SerializeField]
    private MovementDirection horizontalDirection;

    [Header("Rigidbody")]
    [SerializeField]
    private Rigidbody2D rb2D;
    private float THRUST;
    private bool isLoading;
    public bool IsLoading { get; set; }
    private float cooldown;
#region Unity Functions
    void Awake() {
        cooldown = 0.65f;
        isLoading = false;
        THRUST = 10500.0f;
    }
#endregion
#region Public Functions
    // Call this function to launch the dash
    public void CallStart() {
        StartCoroutine(FreezeYConstraint());
        rb2D.AddForce(new Vector2(horizontalDirection.DirectionToFloat(), .0f) * THRUST);
        StartCoroutine(DashCooldown());
    }
#endregion
#region Private Functions
    // Freeze constraints to avoid vertical moving during the dash
    private IEnumerator FreezeYConstraint() {
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(0.25f);
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    // Need a cooldown to avoid dash spamming
    private IEnumerator DashCooldown() {
        IsLoading = true;
        yield return new WaitForSeconds(cooldown);
        IsLoading = false;
    }
#endregion

}
