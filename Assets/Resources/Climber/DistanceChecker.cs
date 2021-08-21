using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Climber {
    /// <summary>
    ///     Concern : Verify the distance between the attached collider and a collider on the layer wallLayer.
    ///     Usage : ???
    ///     Dependency : 
    ///         - Climber.CollisionChecker
    /// </summary>
    public class DistanceChecker : MonoBehaviour
    {
        [Header("Wall layer")]
        [SerializeField]
        private LayerMask wallLayer;

        [Header("Climber data")]
        [SerializeField]
        private ClimberData data;

        [Header("Transform")]
        [SerializeField]
        private Transform transform;

        [Header("Collider")]
        [SerializeField]
        private PolygonCollider2D collider;

        private Climber.CollisionChecker collisionChecker;

        void Start() {
            collisionChecker = new Climber.CollisionChecker(data);
        }

        void FixedUpdate() {
            collisionChecker.UpdateCheckDistance(collider.bounds.extents.y);
        }

        public bool CheckContactWithWall(Vector2[] vectors) {
            foreach(Ray2D ray in CreateRays(vectors)) {
                if (IsInContact(ray, collisionChecker.distanceBetween, wallLayer)) {
                    return true;
                }
            }
            return false;
        }

        private List<Ray2D> CreateRays(Vector2[] vectors) {
            List<Ray2D> rays = new List<Ray2D>();
            foreach(Vector2 vector in vectors) {
                rays.Add(new Ray2D(transform.position, vector));
            }
            return rays;
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
    }
}
