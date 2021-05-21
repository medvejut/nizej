using Damage;
using Guns;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [Title("Ammo")]
        public Text[] ammoText;
        [Required]
        public Slider ammoSlider;
        [Required]
        public Gun gun;

        [Title("HP")]
        public Text[] hpText;
        [Required]
        public Slider hpSlider;
        [Required]
        public Health hp;

        private void Start()
        {
            UpdateAmmo();
            gun.onAmmoReloaded.AddListener(UpdateAmmo);
            gun.onShot.AddListener(UpdateAmmo);
            
            UpdateHP();
            hp.onHit.AddListener(UpdateHP);
        }

        private void UpdateAmmo()
        {
            foreach (var text in ammoText)
            {
                text.text = $"{gun.Ammo}";
            }

            ammoSlider.maxValue = gun.maxAmmo;
            ammoSlider.value = gun.Ammo;
        }

        private void UpdateHP()
        {
            foreach (var text in hpText)
            {
                text.text = $"{hp.Current} / {hp.max}";
            }

            hpSlider.maxValue = hp.max;
            hpSlider.value = hp.Current;
        }
    }
}