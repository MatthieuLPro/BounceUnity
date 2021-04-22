using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDistance : MonoBehaviour
{
    [Header("Game object")]
    [SerializeField]
    private GameObject go;
    [Header("Wall layer")]
    [SerializeField]
    private LayerMask wallLayer;
    private Transform transform;
    private Collider2D collider2D;
    private float distanceBetween;
    private float WALL_DISTANCE_OFFSET = 1.85f;

#region Functions Unity    
    void Start()
    {
        transform = go.GetComponent<Transform>();
        collider2D = go.GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        UpdateCheckDistance();
    }
#endregion
#region Functions public
    public bool CheckContactWithWall(Vector2[] vectors) {
        bool isInContact = false;
        List<Ray2D> rays = CreateCollectionRays(vectors);
        foreach(Ray2D ray in rays) {
            if (IsInContact(ray, distanceBetween, wallLayer)) {
                isInContact = true;
            }
        }
        return isInContact;
    }
#endregion
#region Functions private
    private List<Ray2D> CreateCollectionRays(Vector2[] vectors) {
        List<Ray2D> rays = new List<Ray2D>();
        foreach(Vector2 vector in vectors) {
            rays.Add(new Ray2D(transform.position, vector));
        }
        return rays;
    }
    private void UpdateCheckDistance() {
        if (distanceBetween != collider2D.bounds.extents.y + WALL_DISTANCE_OFFSET) {
            distanceBetween = collider2D.bounds.extents.y + WALL_DISTANCE_OFFSET;
        }
    }
    private bool IsInContact(Ray2D ray, float distance, LayerMask layer) {
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, layer);
        if(hit) {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
            return true;
        } else {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
            return false;
        }
    }
#endregion    
}
