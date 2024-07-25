using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }   

    [SerializeField] PlayerInputActions playerInputActions;

    public event Action<InputAction.CallbackContext> OnInteractAction;
    public event Action<InputAction.CallbackContext> OnInventoryToggle;
    public event Action<InputAction.CallbackContext> OnBookToggle;

    private void Awake() {

        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }
    void Start()
    {

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.Inventory.performed += Inventory_performed;
        playerInputActions.Player.Book.performed += Book_performed;
                
    }

    private void Book_performed(InputAction.CallbackContext context) {
        OnBookToggle?.Invoke(context);
    }

    private void Interact_performed(InputAction.CallbackContext context) {
        OnInteractAction?.Invoke(context);
    }
    private void Inventory_performed(InputAction.CallbackContext context) {
        OnInventoryToggle?.Invoke(context);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy() {

        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.Inventory.performed -= Inventory_performed;
        playerInputActions.Dispose();

    }

    public Vector2 GetMovementNormalize() {

        Vector2 input = playerInputActions.Player.Move.ReadValue<Vector2>();

        input = input.normalized;

        return input;

    }
}
