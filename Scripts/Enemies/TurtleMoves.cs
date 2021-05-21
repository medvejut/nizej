using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Enemies
{
    public class TurtleMoves : MonoBehaviour
    {
        public float speed = 2f;

        [OnInspectorGUI("UpdateDirectionView")]
        public bool upside = true;

        [ChildGameObjectsOnly]
        public Transform directionView;

        [Title("Walls", "Invert direction when collide with wall")]
        public LayerMask wallsLayerMask;

        public Vector2 wallsOffset = Vector2.zero;
        public float wallsDistance = 1f;

        public float suckDistance = 1f;

        private bool _suckToRight = true;

        private void Update()
        {
            UpdateDirectionView();

            var direction = GetDirection();
            transform.Translate(direction * (speed * Time.deltaTime));

            var hit = Physics2D.Raycast(GetWallsCenter(), direction, wallsDistance, wallsLayerMask);
            if (hit.collider)
            {
                upside = !upside;
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.yellow;
            Handles.ArrowHandleCap(0, GetWallsCenter(), Quaternion.LookRotation(GetDirection()), wallsDistance,
                EventType.Repaint);
            Handles.color = Color.white;
            Handles.ArrowHandleCap(0, GetWallsCenter(),
                Quaternion.LookRotation(_suckToRight ? Vector3.right : Vector3.left), suckDistance,
                EventType.Repaint);
        }
#endif

        private Vector3 GetWallsCenter()
        {
            return transform.position + (Vector3) wallsOffset;
        }

        private Vector3 GetDirection()
        {
            return Vector3.up * (upside ? 1 : -1);
        }

        private void UpdateDirectionView()
        {
            if (directionView == null)
                return;

            SuckToWall();

            var scale = directionView.localScale;
            scale.x = _suckToRight ? 1 : -1;
            scale.z = upside ? -1 : 1;
            directionView.localScale = scale;
        }

        private void SuckToWall()
        {
            var hit = Physics2D.Raycast(GetWallsCenter(), Vector2.right, suckDistance, wallsLayerMask);
            if (hit.collider)
            {
                _suckToRight = true;
                return;
            }

            hit = Physics2D.Raycast(GetWallsCenter(), Vector2.left, suckDistance, wallsLayerMask);
            if (hit.collider)
            {
                _suckToRight = false;
            }
        }
    }
}