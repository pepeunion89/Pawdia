using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimatedScript : MonoBehaviour {
        
    public Transform CatHD;
    public CatFight CatFightComponent;

    private void Awake() {

        CatFightComponent = gameObject.GetComponent<CatFight>();
        CatFightComponent.CatStartAnimation += CatAnimatedScript_CatStartAnimation;
        CatFightComponent.CatWatchingAnimation += CatAnimatedScript_CatWatchingAnimation;

    }

    private void CatAnimatedScript_CatWatchingAnimation(object animatorCat, EventArgs e) {
        CatWatchingAnimation(animatorCat as Animator);
    }

    private void CatAnimatedScript_CatStartAnimation(object animatorCat, EventArgs e) {
        CatIdleStartAnimation(animatorCat as Animator);
    }

    void CatIdleStartAnimation(Animator animatorCat) {

        switch (CatFightComponent.catSO.raceName) {

            case "Black":
                animatorCat.SetBool(Constants.CatFightConstants.IsBlack, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingBlack, false);

                break;

            case "Blue":
                animatorCat.SetBool(Constants.CatFightConstants.IsBlue, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingBlue, false);

                break;

            case "Calico":
                animatorCat.SetBool(Constants.CatFightConstants.IsCalico, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingCalico, false);

                break;

            case "Orange":
                animatorCat.SetBool(Constants.CatFightConstants.IsOrange, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingOrange, false);

                break;

            case "Siamese":
                animatorCat.SetBool(Constants.CatFightConstants.IsSiamese, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingSiamese, false);

                break;

            case "Tortoiseshell":
                animatorCat.SetBool(Constants.CatFightConstants.IsTortoiseshell, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingTortoiseshell, false);

                break;

            case "Tuxedo":
                animatorCat.SetBool(Constants.CatFightConstants.IsTuxedo, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingTuxedo, false);

                break;

            case "White":
                animatorCat.SetBool(Constants.CatFightConstants.IsWhite, true);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingWhite, false);

                break;


        }

    }

    void CatWatchingAnimation(Animator animatorCat) {

        switch (CatFightComponent.catSO.raceName) {

            case "Black":
                animatorCat.SetBool(Constants.CatFightConstants.IsBlack, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingBlack, true);

                break;

            case "Blue":
                animatorCat.SetBool(Constants.CatFightConstants.IsBlue, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingBlue, true);

                break;

            case "Calico":
                animatorCat.SetBool(Constants.CatFightConstants.IsCalico, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingCalico, true);

                break;

            case "Orange":
                animatorCat.SetBool(Constants.CatFightConstants.IsOrange, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingOrange, true);

                break;

            case "Siamese":
                animatorCat.SetBool(Constants.CatFightConstants.IsSiamese, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingSiamese, true);

                break;

            case "Tortoiseshell":
                animatorCat.SetBool(Constants.CatFightConstants.IsTortoiseshell, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingTortoiseshell, true);

                break;

            case "Tuxedo":
                animatorCat.SetBool(Constants.CatFightConstants.IsTuxedo, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingTuxedo, true);

                break;

            case "White":
                animatorCat.SetBool(Constants.CatFightConstants.IsWhite, false);
                animatorCat.SetBool(Constants.CatFightConstants.WatchingWhite, true);

                break;

        }

    }
}
