using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGames : MonoBehaviour
{
    public static CatGames Instance { get; private set; }

    public Sprite[] lisCatGames;

    private void Awake() {
        Instance = this;
    }


    public Sprite black_laser;
    public Sprite blue_feather;
    public Sprite calico_paperball;
    public Sprite orange_wetfood;
    public Sprite siamese_catnipball;
    public Sprite tortoiseshell_scratcher;
    public Sprite tuxedo_woolball;
    public Sprite white_teddymouse;
}
