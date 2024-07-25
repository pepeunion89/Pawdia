using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaveFight : MonoBehaviour
{
    [SerializeField] public Button leaveFightButton;
    
    void Start()
    {
        leaveFightButton.onClick.AddListener(OnButtonClick);

        }

    private void OnButtonClick() {
        SceneManager.LoadScene("GameScene");
    }
   
    
}
