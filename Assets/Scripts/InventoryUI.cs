using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance {  get; private set; }

    [SerializeField] private RectTransform EquippedSlot;
    [SerializeField] private RectTransform[] listUnequippedSlots;
    [SerializeField] public Sprite transparentSprite;
    private CatSO[] listCat;
    private Inventory inventory;

    private void Awake() {

        Instance = this;

        Player.Instance.ResetPositionUnequippedSlots += InventoryUI_ResetPositionUnequippedSlots;

    }

    private void Start() {



    }    

    public void Refresh_Inventory(List<CatGameSO> listCatGames) {

        for (int position = 0; position < 8; position++) {

            if (listCatGames[position] == null) {

                listUnequippedSlots[position].GetComponent<Draggable>().catGameSO = null;
                listUnequippedSlots[position].GetComponent<Image>().sprite = transparentSprite;

            } else {

                listUnequippedSlots[position].GetComponent<Draggable>().catGameSO = listCatGames[position];
                listUnequippedSlots[position].GetComponent<Image>().sprite = listCatGames[position].gameSprite;

            }

        }

        
    }

    public void SetInventory(Inventory inventory) {

        this.inventory = inventory;

        inventory.OnInventoryRefresh += InventoryUI_OnInventoryRefresh;

    }
    private void InventoryUI_OnInventoryRefresh(object listCatGames, EventArgs e) {
        Refresh_Inventory(listCatGames as List<CatGameSO>);
    }
    private void InventoryUI_ResetPositionUnequippedSlots(object sender, EventArgs e) {
        
        foreach(RectTransform unequippedSlot in listUnequippedSlots) {
            unequippedSlot.GetComponent<RectTransform>().localPosition = Vector2.zero;
            unequippedSlot.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        EquippedSlot.GetComponent<RectTransform>().localPosition = Vector2.zero;
        EquippedSlot.GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

}
