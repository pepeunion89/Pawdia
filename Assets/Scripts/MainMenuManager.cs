using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] public Button startButton;
    [SerializeField] public Button optionsButton;
    [SerializeField] public OptionsMenu optionsMenu;

    public event EventHandler OnToggleOptionsUI;
    void Start()
    {

        startButton.onClick.AddListener(OnStart);
        optionsButton.onClick.AddListener(OnOptions);

        OnToggleOptionsUI += optionsMenu.OptionsMenu_OnToggleOptionsUI;

    }

    void OnStart() {
        SceneManager.LoadScene("GameScene");
    }

    void OnOptions() {

        OnToggleOptionsUI.Invoke(this, EventArgs.Empty);

    }


}
