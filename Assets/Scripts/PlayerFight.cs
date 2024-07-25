using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFight : MonoBehaviour
{
    public static PlayerFight Instance { get; private set; }
    public event EventHandler OnCatWatchingAnimation;

    [SerializeField] public CatGameSO catGameSO;
    [SerializeField] public Button btnDropGame;
    [SerializeField] public Transform GameDroppedArea;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        btnDropGame.onClick.AddListener(DropGame);
    }

    void Update()
    {
        
    }

    void DropGame() {
        btnDropGame.gameObject.SetActive(false);
        GameDroppedArea.gameObject.SetActive(true);
        GameDroppedArea.Find("Game").GetComponent<SpriteRenderer>().sprite = catGameSO.gameSprite;

        OnCatWatchingAnimation.Invoke(catGameSO, EventArgs.Empty);

    }
}
