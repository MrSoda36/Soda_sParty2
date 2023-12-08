using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryInput : MonoBehaviour
{
    [SerializeField] private KeyCode _key;

    public event Action OnKeyPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            OnKeyPressed?.Invoke();
        }
    }
}
