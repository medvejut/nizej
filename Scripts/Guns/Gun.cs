using Core;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Guns
{
    public class Gun : MonoBehaviour
    {
        [AssetsOnly]
        public Bullet bulletPrefab;

        [MinValue(0f), MaxValue(180f)]
        public Vector3 spreadAngle = Vector3.zero;

        [MinValue(0f)]
        public float delayBetweenShots = 1f;

        [MinValue(1)]
        public int maxAmmo = 5;

        [FoldoutGroup("Events")]
        public UnityEvent onShot, onAmmoReloaded, onNoAmmo;
        
        public int Ammo { get; private set; }

        private Transform _bulletsParent;
        private float _lastShotTime;

        private void Start()
        {
            _bulletsParent = new GameObject($"[Temp] {name}").transform;
            ReloadAmmo();
        }

        [Title("Test", "PlayMode Only"), Button(ButtonSizes.Large), GUIColor(0.2f, 0.8f, 1f), DisableInEditorMode]
        public void Shoot()
        {
            if (!CanShoot())
            {
                if (Ammo == 0) onNoAmmo.Invoke();
                return;
            }

            _lastShotTime = Time.time;
            Ammo--;

            var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, _bulletsParent);
            var randomSpread = Vector3.Scale(Random.insideUnitSphere, spreadAngle);
            Vector2 direction = Quaternion.Euler(randomSpread) * transform.forward;
            bullet.Direction = direction;

            onShot.Invoke();
        }

        private bool CanShoot()
        {
            return Ammo > 0 && Time.time - _lastShotTime > delayBetweenShots;
        }

        public void ReloadAmmo()
        {
            Ammo = maxAmmo;
            onAmmoReloaded.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position, 0.125f);
            GGizmos.DrawArrow(transform.position, transform.forward);

            if (spreadAngle.x > 0f)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, Quaternion.Euler(-spreadAngle.x, 0, 0) * transform.forward);
                Gizmos.DrawRay(transform.position, Quaternion.Euler(spreadAngle.x, 0, 0) * transform.forward);
            }

            if (spreadAngle.y > 0f)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -spreadAngle.y, 0) * transform.forward);
                Gizmos.DrawRay(transform.position, Quaternion.Euler(0, spreadAngle.y, 0) * transform.forward);
            }

            if (spreadAngle.z > 0f)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, -spreadAngle.z) * transform.forward);
                Gizmos.DrawRay(transform.position, Quaternion.Euler(0, 0, spreadAngle.z) * transform.forward);
            }
        }
    }
}