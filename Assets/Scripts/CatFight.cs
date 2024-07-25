using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFight : MonoBehaviour
{

    public event EventHandler CatStartAnimation;
    public event EventHandler CatWatchingAnimation;

    [SerializeField] public CatSO catSO;
    [SerializeField] public Transform CatHD;
    [SerializeField] public GameObject FallInLove;
    private Animator AnimatorCat;

    void Start()
    {
        PlayerFight.Instance.OnCatWatchingAnimation += CatFight_OnCatWatchingAnimation;
        CatHD.GetComponent<SpriteRenderer>().sprite = catSO.raceSprite;
        AnimatorCat = CatHD.GetComponent<Animator>();
        CatStartAnimation.Invoke(AnimatorCat, EventArgs.Empty);
    }

    private void CatFight_OnCatWatchingAnimation(object catGameSO, EventArgs e) {
        CatWatchingAnimation.Invoke(AnimatorCat, EventArgs.Empty);

        StartCoroutine(WaitForCatPlaying(catGameSO as CatGameSO));
    }

    public IEnumerator WaitForCatPlaying(CatGameSO catGameSO) {
        yield return new WaitForSeconds(3);

        if (catGameSO == catSO.catGameSO) {
            FallInLove.SetActive(true);
            CatStartAnimation.Invoke(AnimatorCat, EventArgs.Empty);

            SceneChangeManager.listBookCatSO[catSO.raceID] = catSO;

        } else {
            CatStartAnimation.Invoke(AnimatorCat, EventArgs.Empty);
        }
    }
}
