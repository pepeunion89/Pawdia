using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Show_Box : MonoBehaviour {
    public static NPC_Show_Box Instance { get; private set; }

    public bool boxIsOpened = false;
    public int lastNPC_ID;
    public RectTransform lastBox;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Player.Instance.CheckBoxOpened += NPC_Show_Box_CheckBoxOpened;
    }    

    public void ShowBox(int NPC_ID, RectTransform box) {

        switch (NPC_ID) {

            case 0:

                boxIsOpened = !boxIsOpened;
                box.gameObject.SetActive(boxIsOpened);

                lastNPC_ID = NPC_ID;
                lastBox = box;

                Debug.Log("Welcome guy");

                break;

            case 1:

                boxIsOpened = !boxIsOpened;
                box.gameObject.SetActive(boxIsOpened);

                lastNPC_ID = NPC_ID;
                lastBox = box;

                Debug.Log("Shop girl");

                break;


        }

    }

    private void NPC_Show_Box_CheckBoxOpened(object sender, EventArgs e) {
        if (boxIsOpened == true) {
            ShowBox(lastNPC_ID, lastBox);
        }
    }


}
