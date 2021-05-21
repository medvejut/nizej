using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core
{
    public class LightIntensityOverTime : MonoBehaviour
    {
        public new Light light;
        public bool onStart = true;
        [MinValue(float.Epsilon)]
        public float duration = 1f;
        public bool fromCurrent = true;
        [HideIf("fromCurrent"), Indent(1)]
        public float from = 1f;
        public float to;
        public AnimationCurve curve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        private void Reset()
        {
            light = GetComponent<Light>();
        }

        private void Start()
        {
            if (onStart)
            {
                Play();
            }
        }

        [Button]
        public void Play()
        {
            if (!light)
            {
                Debug.LogWarning("No light attached");
                return;
            }

            StartCoroutine(PlayCoroutine());
        }

        private IEnumerator PlayCoroutine()
        {
            var startTime = Time.time;
            var fromIntensity = fromCurrent ? light.intensity : from;
            float elapsedTime;
            while ((elapsedTime = Time.time - startTime) < duration)
            {
                yield return null;
                var time = curve.Evaluate(elapsedTime / duration);
                light.intensity = Mathf.Lerp(fromIntensity, to, time);
            }

            light.intensity = to;
        }
    }
}