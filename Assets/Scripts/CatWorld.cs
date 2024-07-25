using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CatWorld : MonoBehaviour, IInteractable
{
    public static CatWorld Instance {  get; private set; }

    private void Awake() {
        Instance = this;
    }


    [SerializeField] private string collideMessage;
    [SerializeField] private Transform boxMessage;
    [SerializeField] private TextMeshProUGUI textMessage;
    [SerializeField] private RectTransform imageTextPlayer;
    [SerializeField] private CatSO catSO;
    public void Interact() {

        if (Player.Instance.GetInventory().GetCatGames()[8] != null) {

            SceneChangeManager.playerGameEquipped = Player.Instance.GetInventory().GetCatGames()[8];
            SceneChangeManager.catSO = this.catSO;
            SceneChangeManager.playerPositionXY[0] = Player.Instance.transform.localPosition.x;
            SceneChangeManager.playerPositionXY[1] = Player.Instance.transform.localPosition.y;
            SceneChangeManager.sceneFlag = 1;
            SceneManager.LoadScene("FightScene");
        } else {
            StartCoroutine(ShowAndHideMessage());
        }
            
    }
    public string GetInteractMessage() {
        return collideMessage;
    }

    public void ShowMessage() {
        textMessage.text = collideMessage;
        boxMessage.gameObject.SetActive(true);
    }

    public void HideMessage() {
        textMessage.text = "";
        boxMessage.gameObject.SetActive(false);
    }

    public IEnumerator ShowAndHideMessage() {
        imageTextPlayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        imageTextPlayer.gameObject.SetActive(false);
    }
}
