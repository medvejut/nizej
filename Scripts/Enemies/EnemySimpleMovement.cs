using Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Enemies
{
    public class EnemySimpleMovement : MonoBehaviour
    {
        [MinValue(-1f), MaxValue(1f)]
        public Vector2 speedAxis = Vector2.right;

        public float speed = 10f;
        public LayerMask groundLayerMask;

        [MaxValue(1f)]
        public Vector2 groundDirection = Vector2.down;

        public float groundDistance = 1f;
        public Vector2 forwardGroundOffset;
        public Vector2 backwardGroundOffset;
        public Vector2 wallsOffset;
        public float wallsDistance = 1f;
        public bool moveForward = true;

        private void Update()
        {
            var direction = GetSpeedAxis(moveForward);
            transform.Translate(direction * (speed * Time.deltaTime));

            var hit = Physics2D.Raycast(GetGroundPosition(moveForward), groundDirection, groundDistance,
                groundLayerMask);
            if (!hit.collider)
            {
                moveForward = !moveForward;
            }
            else
            {
                hit = Physics2D.Raycast(GetWallsPosition(), GetSpeedAxis(moveForward), wallsDistance, groundLayerMask);
                if (hit.collider)
                {
                    moveForward = !moveForward;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;

            var position = GetGroundPosition(true);
            var wallsPosition = GetWallsPosition();
            GGizmos.DrawArrow(position, groundDirection * groundDistance, 0.15f);
            GGizmos.DrawArrow(wallsPosition, GetSpeedAxis(true) * wallsDistance, 0.15f);
            position = GetGroundPosition(false);
            GGizmos.DrawArrow(position, groundDirection * groundDistance, 0.15f);
            GGizmos.DrawArrow(wallsPosition, GetSpeedAxis(false) * wallsDistance, 0.15f);
        }

        private Vector2 GetGroundPosition(bool forward)
        {
            return (Vector2) transform.position + (forward ? forwardGroundOffset : backwardGroundOffset);
        }

        private Vector2 GetSpeedAxis(bool forward)
        {
            return forward ? speedAxis : -speedAxis;
        }

        private Vector2 GetWallsPosition()
        {
            return (Vector2) transform.position + wallsOffset;
        }
    }
}