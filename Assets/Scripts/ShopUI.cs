using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{

    [SerializeField] public RectTransform[] listRectTransformGames;
    void Start()
    {
        
        foreach(RectTransform game in listRectTransformGames) {
            BuyScript buyScriptGame = game.GetComponent<BuyScript>();
            TextMeshProUGUI priceText = game.Find("Price").GetComponent<TextMeshProUGUI>();
            priceText.text = buyScriptGame.catGameSO.gamePrice.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
