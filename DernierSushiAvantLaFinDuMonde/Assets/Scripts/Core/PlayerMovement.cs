using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 MoveValue;
    public void Movement(InputAction.CallbackContext context)
    {
        MoveValue = context.ReadValue<Vector2>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
