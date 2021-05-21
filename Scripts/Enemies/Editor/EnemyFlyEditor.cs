using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Enemies.Editor
{
    [CustomEditor(typeof(EnemyFly))]
    public class EnemyFlyEditor : OdinEditor
    {
        private void OnSceneGUI()
        {
            var enemyFly = target as EnemyFly;
            
            Handles.color = Color.yellow;
            var targetPosition = enemyFly.GetTargetPosition();
            if (enemyFly.target == null)
            {
                Handles.DrawWireCube(targetPosition, Vector3.one * 0.4f);

                EditorGUI.BeginChangeCheck();
                targetPosition = Handles.PositionHandle(targetPosition, Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(enemyFly, "Change EnemyFly target");
                    enemyFly.targetPosition = targetPosition;
                }
            }

            Handles.DrawDottedLine(enemyFly.transform.position, targetPosition, 1);
        }
    }
}