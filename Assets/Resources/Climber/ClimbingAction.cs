using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace Climber {
    /// <summary>
    ///     Concern : Manage the logic of climbing.
    ///     Usage : Attached to a gameObject
    ///     Dependency : 
    ///         - Stamina.StaminaCore
    ///         - Climber.DistanceChecker
    /// </summary>
    public class ClimbingAction : MonoBehaviour
    {
        [Header("Game object")]
        [SerializeField]
        private GameObject go; 

        [Header("Movement Horizontal direction")]
        [SerializeField]
        private MovementDirection horizontalDirection;

        private Rigidbody2D rb2d;
        private Climber.DistanceChecker distanceChecker;
        private bool isClimbing;

        [Header("Player input")]
        [SerializeField]
        private PlayerInput playerInput;

        public enum Direction {
            Right,
            Left,
            None
        };
        private Direction climbingDirection;

        private Stamina.StaminaCore stamina;

        public void Start() {
            rb2d = go.GetComponent<Rigidbody2D>();
            distanceChecker = GetComponent<Climber.DistanceChecker>();
            isClimbing = false;
            climbingDirection = Direction.None;
            stamina = SetStaminaCore();
        }
        public void Update() {
            if (stamina != null) {
                ManageStaminaConsomation();
            }
        }

        // Should call specific function depending of the 
        // Movement direction
        public void StartClimbing() {
            if (horizontalDirection.IsLeft() && distanceChecker.CheckContactWithWall(new Vector2[1] { Vector2.left })) {
                SetClimbingStatus(Direction.Left);
            } else if (horizontalDirection.IsRight() && distanceChecker.CheckContactWithWall(new Vector2[1] { Vector2.right })) {
                SetClimbingStatus(Direction.Right);
            }
        }

        public void CancelClimbing() {
            RemoveClimbingStatus();
        }

        public bool IsClimbing() {
            return isClimbing;
        }
        public Direction CurrentDirection() {
            return climbingDirection;
        }

        private Stamina.StaminaCore SetStaminaCore() {
            Transform staminaTransform = transform.Find("Stamina");
            return staminaTransform != null ? staminaTransform.GetComponent<Stamina.StaminaCore>() : null;
        }
        private void ManageStaminaConsomation() {
            if(isClimbing) {
                if (stamina.CanConsumeStamina()) {
                    stamina.UpdateConsumingStamina(true);
                } else {
                    stamina.UpdateConsumingStamina(false);
                    CancelClimbing();
                    playerInput.SwitchCurrentActionMap("Gameplay");
                }
            } else if (!isClimbing) {
                stamina.UpdateConsumingStamina(false);
            }
        }
        private void SetClimbingStatus(Direction climbDirection) {
            rb2d.velocity = Vector2.zero;
            rb2d.bodyType = RigidbodyType2D.Kinematic;
            isClimbing = true;
            climbingDirection = climbDirection;
        }
        private void RemoveClimbingStatus() {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            isClimbing = false;
            climbingDirection = Direction.None;
        }
    }
}
