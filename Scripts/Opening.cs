using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Opening : MonoBehaviour
{
    public UnityEvent onPlay;
    public UnityEvent onQuit;

    private void Start()
    {
        Cursor.visible = false;
    }

    public void Play(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        onPlay.Invoke();
    }

    public void Quit(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        onQuit.Invoke();
    }
}