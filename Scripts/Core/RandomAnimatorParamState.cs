using Sirenix.OdinInspector;
using UnityEngine;

namespace Core
{
    [InfoBox("OnStateEnter", InfoMessageType.None)]
    public class RandomAnimatorParamState : StateMachineBehaviour
    {
        [Required]
        public string paramID;

        public int minInclusive, maxExclusive;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            
            var random = Random.Range(minInclusive, maxExclusive);
            animator.SetInteger(paramID, random);
        }
    }
}