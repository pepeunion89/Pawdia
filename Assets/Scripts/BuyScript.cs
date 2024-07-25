using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    [SerializeField] public CatGameSO catGameSO;

    private void Start() {

        buyButton.onClick.AddListener(OnBuyGame);

    }

    void OnBuyGame() {

        if(Player.Instance.money >= catGameSO.gamePrice) {
            Player.Instance.money -= catGameSO.gamePrice;
            Player.Instance.moneyTransform.text = Player.Instance.money.ToString();

            Player.Instance.GetInventory().AddCatGame(catGameSO);


        }

    }


}
