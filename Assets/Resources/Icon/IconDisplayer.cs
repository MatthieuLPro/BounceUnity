using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Icon {
    /// <summary>
    ///     Concern : Display specific icon.
    ///     Usage : Attached to a gameObject with boxCollider
    /// </summary>
    public class IconDisplayer : MonoBehaviour
    {
        [Header("Icon to display")]
        [SerializeField]
        private GameObject icon;

        public void OnTriggerEnter2D(Collider2D collider) {
            if (collider.tag == "Player") {
                icon.SetActive(true);
            }
        }

        public void OnTriggerExit2D(Collider2D collider) {
            if (collider.tag == "Player") {
                icon.SetActive(false);
            }
        }
    }
}
