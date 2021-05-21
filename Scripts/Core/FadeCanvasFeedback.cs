using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core
{
    public class FadeCanvasFeedback : MonoBehaviour
    {
        public CanvasGroup target;

        [Range(0f, 1f)]
        public float to;

        public bool fromCurrent = true;

        [HideIf(nameof(fromCurrent)), Indent]
        [Range(0f, 1f)]
        public float from;

        public float duration = 1f;
        public Ease ease = Ease.OutQuad;
        public bool yoyo;
        public float delay;

        [ContextMenu("Play")]
        public void Play()
        {
            if (!fromCurrent)
            {
                target.alpha = from;
            }

            var tween = target.DOFade(to, duration).SetEase(ease).SetDelay(delay);
            if (yoyo)
            {
                tween.SetLoops(2, LoopType.Yoyo);
            }
        }
    }
}