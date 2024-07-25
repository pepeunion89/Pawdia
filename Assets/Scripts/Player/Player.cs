using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player Instance {  get; private set; }

    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform boy;
    [SerializeField] private Image inventoryUI;
    [SerializeField] public TextMeshProUGUI moneyTransform;
    [SerializeField] public int money;
    [SerializeField] private InventoryUI inventoryUIScript;
    [SerializeField] private Image bookUI;
    [SerializeField] private BookUI bookUIScript;
    private Inventory inventory;
    private Book book;
    private bool IsWalking;
    private bool InventoryIsOpen = false;
    private bool BookIsOpen = false;

    private IInteractable currentInteractable;

    public event EventHandler CheckBoxOpened;
    public event EventHandler ResetPositionUnequippedSlots;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        inventory = new Inventory();
        inventoryUIScript.SetInventory(inventory);

        book = new Book();
        bookUIScript.SetBookList(book);
    }

    private void Start() {
        
        if(SceneChangeManager.startGameFlag == 0) {

            for (int catSoCounter = 0; catSoCounter < 8; catSoCounter++) {
                SceneChangeManager.listBookCatSO.Add(null);
            }

            SceneChangeManager.startGameFlag = 1;
        }       

        if (SceneChangeManager.sceneFlag != 0) {
            gameObject.transform.localPosition = new Vector2(SceneChangeManager.playerPositionXY[0], SceneChangeManager.playerPositionXY[1]);

            for (int booxIdx = 0; booxIdx < 8; booxIdx++) {
            
                book.AddCatSOToBook(booxIdx, SceneChangeManager.listBookCatSO[booxIdx]);
            
            }

        }

        moneyTransform.text = money.ToString();

        playerController.OnInteractAction += Player_OnInteractAction;
        playerController.OnInventoryToggle += Player_OnInventoryToggle;
        playerController.OnBookToggle += Player_OnBookToggle;

    }

    private void Player_OnBookToggle(InputAction.CallbackContext context) {
        BookIsOpen = !BookIsOpen;
        bookUI.gameObject.SetActive(BookIsOpen);
    }

    private void Player_OnInteractAction(InputAction.CallbackContext context) {

        if (currentInteractable != null) {
            currentInteractable.Interact();
        }

    }
    private void Player_OnInventoryToggle(InputAction.CallbackContext context) {
        InventoryIsOpen = !InventoryIsOpen;
        inventoryUI.gameObject.SetActive(InventoryIsOpen);
        ResetPositionUnequippedSlots.Invoke(this, EventArgs.Empty);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move() {

        Vector2 direction = playerController.GetMovementNormalize();

        playerMovement.HandleMovement(direction);

        playerMovement.UpdateDirectionMovementAnimation(direction, boy);
        
    }

    private void OnTriggerEnter2D(Collider2D colliderEnter) {

        if (colliderEnter.TryGetComponent(out IInteractable interactableObject)) {
            currentInteractable = interactableObject;
            currentInteractable.ShowMessage();
        }        

    }

    private void OnTriggerExit2D(Collider2D colliderExit) {
        
        if(colliderExit.TryGetComponent(out IInteractable interactableObject) && interactableObject == currentInteractable) {
            currentInteractable.HideMessage();
            currentInteractable = null;

            CheckBoxOpened.Invoke(this, EventArgs.Empty);

        }

    }

    public Inventory GetInventory() {
        return inventory;
    }

    public Book GetBook() {
        return book;
    }

}
