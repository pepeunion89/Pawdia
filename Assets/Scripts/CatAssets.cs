using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAssets : MonoBehaviour
{
    
    public static CatAssets Instance { get; private set; }

    public Sprite[] listRacesHD;

    private void Awake() {
        Instance = this;
    }


    public Sprite black;
    public Sprite blue; 
    public Sprite calico;
    public Sprite orange;
    public Sprite siamese;
    public Sprite tortoiseshell;
    public Sprite tuxedo;
    public Sprite white;

}
