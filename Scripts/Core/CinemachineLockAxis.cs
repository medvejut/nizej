using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core
{
    [AddComponentMenu("")]
    [ExecuteAlways]
    public class CinemachineLockAxis : CinemachineExtension
    {
        [TitleGroup("Axis"), LabelWidth(16), HorizontalGroup("Axis/xyz")]
        public bool x;
        
        [LabelWidth(16), HorizontalGroup("Axis/xyz")]
        public bool y;
        
        [LabelWidth(16), HorizontalGroup("Axis/xyz")]
        public bool z;
        
        [EnableIf("@this.x || this.y || this.z")]
        public Vector3 position;

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            var rawPosition = state.RawPosition;
            if (x) rawPosition.x = position.x;
            if (y) rawPosition.y = position.y;
            if (z) rawPosition.z = position.z;
            state.RawPosition = rawPosition;
        }
    }
}