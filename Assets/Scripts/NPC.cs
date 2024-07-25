using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IInteractable
{

    [SerializeField] private string collideMessage;
    [SerializeField] private Transform boxMessage;
    [SerializeField] private TextMeshProUGUI textMessage;
    [SerializeField] private int NPC_ID;
    [SerializeField] private NPC_Show_Box NPC_Show_Box;
    [SerializeField] private RectTransform box;

    private void Start() {

    }
    public string GetInteractMessage() {
        return collideMessage;
    }

    public void Interact() {
        NPC_Show_Box.ShowBox(NPC_ID, box);
    }

    public void ShowMessage() {
        textMessage.text = collideMessage;
        boxMessage.gameObject.SetActive(true);
    }

    public void HideMessage() {
        textMessage.text = "";
        boxMessage.gameObject.SetActive(false);
    }

}
