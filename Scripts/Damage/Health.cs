using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Damage
{
    public class Health : MonoBehaviour
    {
        public int max = 100;
        
        public bool destroyOnDeath = true;
        [ShowIf("destroyOnDeath")]
        public float destructionDelay;

        public bool invulnerabilityOnHit;
        [ShowIf("invulnerabilityOnHit"), MinValue(0f)]
        public float invulnerabilityDuration = 1f;
        
        [FoldoutGroup("Events")]
        public UnityEvent onHit, onDeath;

        public int Current { get; private set; }

        public bool Invulnerable { get; private set; }

        public bool Dead => Current == 0;

        private void Start()
        {
            Current = max;
        }

        public void Damage(int damage)
        {
            if (Invulnerable || Current == 0)
                return;

            Current -= damage;

            if (invulnerabilityOnHit)
            {
                StartCoroutine(InvulnerabilityOn(invulnerabilityDuration));
            }
            
            onHit.Invoke();
            if (Current <= 0)
            {
                Kill();
            }
        }

        private IEnumerator InvulnerabilityOn(float delay)
        {
            Invulnerable = true;
            yield return new WaitForSeconds(delay);
            Invulnerable = false;
        }

        private void Kill()
        {
            Current = 0;
            if (destroyOnDeath)
            {
                Destroy(gameObject, destructionDelay);
            }

            onDeath.Invoke();
        }
    }
}