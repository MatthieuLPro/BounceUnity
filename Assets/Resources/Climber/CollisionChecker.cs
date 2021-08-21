using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Climber {
    /// <summary>
    ///     Concern : Verify the distance between 2 objects and update the distance between if changed.
    ///     Dependency : 
    ///         - ClimberData
    /// </summary>
    public class CollisionChecker
    {
        private ClimberData data;
        public float distanceBetween = 0f;

        public CollisionChecker(ClimberData newData) {
            data = newData;
        }

        public void UpdateCheckDistance(float yCollider) {
            if (DistanceHasChanged(yCollider)) {
                distanceBetween = yCollider + data.wallDistanceOffset;
            }
        }

        private bool DistanceHasChanged(float yCollider) {
            return distanceBetween != yCollider + data.wallDistanceOffset;
        }
    }
}
