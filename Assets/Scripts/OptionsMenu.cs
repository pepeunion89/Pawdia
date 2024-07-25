using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private MainMenuManager mainMenuManager;
    private bool optionsMenuIsActive = false;
    
    public void OptionsMenu_OnToggleOptionsUI(object sender, EventArgs e) {

        optionsMenuIsActive = !optionsMenuIsActive;

        gameObject.SetActive(optionsMenuIsActive);
    }
}
