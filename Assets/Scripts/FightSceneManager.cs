using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{

    [SerializeField] public Transform enemyCatTransform;
    [SerializeField] public Transform playerTransform;
    private CatSO catSO;
    private CatGameSO playerGameEquipped;
    private string catName;
    void Start()
    {
        catSO = SceneChangeManager.catSO;
        playerGameEquipped = SceneChangeManager.playerGameEquipped;
        enemyCatTransform.GetComponent<CatFight>().catSO = catSO;

        playerTransform.GetComponent<PlayerFight>().catGameSO = playerGameEquipped;
    }

    void Update()
    {
        
    }
    
}
