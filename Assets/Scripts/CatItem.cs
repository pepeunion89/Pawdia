using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatItem
{
    
    public enum CatRace {

        black,
        blue, 
        calico,
        orange,
        siamese,
        tortoiseshell,
        tuxedo,
        white

    }

    public CatRace race;    
    public int amount;

    public Sprite GetRaceSprite() {

        switch (race) {

            case CatRace.black:    
                return CatAssets.Instance.black;

            case CatRace.blue:
                return CatAssets.Instance.blue;

            case CatRace.calico:
                return CatAssets.Instance.calico;

            case CatRace.orange:
                return CatAssets.Instance.orange;

            case CatRace.siamese:
                return CatAssets.Instance.siamese;

            case CatRace.tortoiseshell:
                return CatAssets.Instance.tortoiseshell;

            case CatRace.tuxedo:
                return CatAssets.Instance.tuxedo;

            case CatRace.white:
                return CatAssets.Instance.white;

            default: return null;
        }

    }


}
