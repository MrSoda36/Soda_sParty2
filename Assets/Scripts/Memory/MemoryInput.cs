using System;
using UnityEngine;

public class MemoryInput : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    public event Action OnKeyPressed;

    // Update is called once per frame
    // Basically used to detect click 
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            OnKeyPressed?.Invoke();
        }
    }
}
