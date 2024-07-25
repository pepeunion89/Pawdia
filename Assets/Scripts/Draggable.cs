using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerDownHandler {
    [SerializeField] public RectTransform parent;
    [SerializeField] public RectTransform itemTransform;
    [SerializeField] public CatGameSO catGameSO;

    [SerializeField] public Transform catGameImagePutContainer;
    [SerializeField] public Transform catGameImagePut;
    [SerializeField] public Sprite transparentSprite;

    public int itemPosition;
    private RectTransform draggableTransform;
    private bool isNotNull = false;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 vectorDivisor = new Vector2(8.4f, 1.6f);

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData) {

        if (isNotNull == true) {

            canvasGroup.blocksRaycasts = false;
            parent.SetAsLastSibling();
            Debug.Log("On begin drag");

        } else {
            Debug.Log("You are not holding anything.");
        }

    }
    public void OnDrag(PointerEventData eventData) {

        if (isNotNull == true) {

            rectTransform.anchoredPosition += eventData.delta / vectorDivisor;

        } else {
            Debug.Log("You are not holding anything.");
        }

    }

    public void OnEndDrag(PointerEventData eventData) {

        if (isNotNull == true) {

            canvasGroup.blocksRaycasts = true;
            if (gameObject.transform.localPosition != Vector3.zero) {
                gameObject.transform.localPosition = Vector3.zero;
            }

        } else {
            Debug.Log("You are not holding anything.");
        }

    }


    public void OnPointerDown(PointerEventData eventData) {
        draggableTransform = eventData.pointerEnter.gameObject.GetComponent<RectTransform>();
        if (draggableTransform.GetComponent<Draggable>().catGameSO != null) {
            isNotNull = true;
            Debug.Log("Pointer down");
        } else {
            Debug.Log("You are not holding anything.");
        }
    }

    public void OnDrop(PointerEventData eventData) {

        if (eventData.pointerDrag.gameObject.GetComponent<Draggable>().isNotNull) {
            List<CatGameSO> catGameSOList = Player.Instance.GetInventory().GetCatGames();

            int idxDropped = eventData.pointerDrag.gameObject.GetComponent<Draggable>().itemPosition;
            int idxChanged = gameObject.GetComponent<Draggable>().itemPosition;

            GameObject droppedObject = eventData.pointerDrag;
            if (droppedObject != null) {             

                    if (idxDropped == 8 || idxChanged == 8) {
                        if (idxDropped == 8) {

                            if (gameObject.GetComponent<Image>().sprite.name == "transparent") {
                                catGameImagePut.GetComponent<SpriteRenderer>().sprite = null;
                                catGameImagePutContainer.gameObject.SetActive(false);
                            } else {
                                catGameImagePut.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<Image>().sprite;
                                catGameImagePutContainer.gameObject.SetActive(true);
                            }

                        } else {

                            catGameImagePut.GetComponent<SpriteRenderer>().sprite = droppedObject.GetComponent<Image>().sprite;
                            catGameImagePutContainer.gameObject.SetActive(true);

                        }
                    }

                    if(gameObject.GetComponent<Draggable>().catGameSO == null) {

                        gameObject.GetComponent<Draggable>().catGameSO = droppedObject.GetComponent<Draggable>().catGameSO;
                        gameObject.GetComponent<Image>().sprite = droppedObject.GetComponent<Draggable>().catGameSO.gameSprite;

                        droppedObject.GetComponent<RectTransform>().localPosition = Vector2.zero;
                        droppedObject.GetComponent<Draggable>().catGameSO = null;
                        droppedObject.GetComponent<Image>().sprite = transparentSprite;

                    } else {
                        CatGameSO auxCatGameSO = gameObject.GetComponent<Draggable>().catGameSO;

                        gameObject.GetComponent<Draggable>().catGameSO = droppedObject.GetComponent<Draggable>().catGameSO;
                        gameObject.GetComponent<Image>().sprite = droppedObject.GetComponent<Draggable>().catGameSO.gameSprite;

                        droppedObject.GetComponent<RectTransform>().localPosition = Vector2.zero;
                        droppedObject.GetComponent<Draggable>().catGameSO = auxCatGameSO;
                        droppedObject.GetComponent<Image>().sprite = auxCatGameSO.gameSprite;
                    }                    

                    CatGameSO itemAux = catGameSOList[idxDropped];
                    catGameSOList[idxDropped] = catGameSOList[idxChanged];
                    catGameSOList[idxChanged] = itemAux;

                    InventoryUI.Instance.Refresh_Inventory(catGameSOList);

                
            }



        }



    }
}
