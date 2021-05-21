using System;
using System.Collections;
using UnityEngine;

namespace Core
{
    public static class MonoBehaviourDelayExtension
    {
        public static Coroutine DelayUnscaled(this MonoBehaviour monoBehaviour, float seconds, Action handler)
        {
            return monoBehaviour.StartCoroutine(WaitUnscaled(seconds, handler));
        }

        private static IEnumerator WaitUnscaled(float seconds, Action handler)
        {
            yield return new WaitForSecondsRealtime(seconds);
            handler.Invoke();
        }
    }
}