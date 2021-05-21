using UnityEditor;
using UnityEngine;

namespace Levels.Editor
{
    [CustomEditor(typeof(LevelSequence))]
    public class LevelSequenceEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var sequence = target as LevelSequence;
            
            Handles.color = Color.green;
            Handles.Label(sequence.inPosition, $"{target.name} In");
            EditorGUI.BeginChangeCheck();
            var inPosition = Handles.PositionHandle(sequence.inPosition, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(sequence, "Change In position");
                sequence.inPosition = inPosition;
            }
            
            Handles.color = Color.red;
            Handles.Label(sequence.outPosition, $"{target.name} Out");
            EditorGUI.BeginChangeCheck();
            var outPosition = Handles.PositionHandle(sequence.outPosition, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(sequence, "Change Out position");
                sequence.outPosition = outPosition;
            }
        }
    }
}