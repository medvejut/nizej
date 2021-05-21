using Core;
using Damage;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class GameOver : MonoBehaviour
{
    public Health playerHealth;
    public Volume volume;
    public CanvasGroup hud;
    public GameObject gameOverUI;
    public GameObject extraUI;
    public PlayerInput input;

    public float duration = 1f;
    public float uiDelay = 1f;
    public float extraDelay = 2f;

    private void Start()
    {
        playerHealth.onDeath.AddListener(Activate);
        volume.enabled = false;
        volume.weight = 0f;
        gameOverUI.SetActive(false);
        extraUI.SetActive(false);
        input.enabled = false;
    }

    private void Activate()
    {
        volume.enabled = true;
        DOTween.To(() => volume.weight, value => volume.weight = value, 1, duration).SetUpdate(true);
        DOTween.To(() => Time.timeScale, value => Time.timeScale = value, 0, duration).SetUpdate(true)
            .SetEase(Ease.OutExpo);
        hud.DOFade(0, duration).SetUpdate(true);

        this.DelayUnscaled(uiDelay, () => gameOverUI.SetActive(true));
        this.DelayUnscaled(extraDelay, () =>
        {
            extraUI.SetActive(true);
            input.enabled = true;
        });
    }
}