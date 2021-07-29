using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDistance : MonoBehaviour
{
    [Header("Game object")]
    [SerializeField]
    private GameObject go;
    [Header("Box layer")]
    [SerializeField]
    private LayerMask boxLayer;
    private Transform transform;
    private PolygonCollider2D collider;
    private float distanceBetween;
    private float BOX_DISTANCE_OFFSET = 4f;

#region Functions Unity    
    void Start()
    {
        transform = go.GetComponent<Transform>();
        collider = go.GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        UpdateCheckDistance();
    }
#endregion
#region Functions public
    public bool CheckContactWithBox(Vector2[] vectors) {
        bool isInContact = false;
        List<Ray2D> rays = CreateCollectionRays(vectors);
        foreach(Ray2D ray in rays) {
            if (IsInContact(ray, distanceBetween, boxLayer)) {
                isInContact = true;
            }
        }
        return isInContact;
    }

    public GameObject BoxInContact(Vector2[] vectors) {
        List<Ray2D> rays = CreateCollectionRays(vectors);
        foreach(Ray2D ray in rays) {
            return BoxInContact(ray, distanceBetween, boxLayer);
        }
        return null;
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
        if (distanceBetween != collider.bounds.extents.y + BOX_DISTANCE_OFFSET) {
            distanceBetween = collider.bounds.extents.y + BOX_DISTANCE_OFFSET;
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

    private GameObject BoxInContact(Ray2D ray, float distance, LayerMask layer) {
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance, layer);
        return hit.collider.gameObject;
    }
#endregion  
}
