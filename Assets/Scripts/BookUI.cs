using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{

    [SerializeField] private Image[] listCheckedCats;
    private Book book;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RefreshBookList() {

        for (int counter = 0; counter < 8; counter++) {

            if (book.GetCatSOList()[counter] != null) {
                listCheckedCats[counter].gameObject.SetActive(true);
            }

        }

    }
    public void SetBookList(Book book) {

        this.book = book;
        book.RefreshBookList += BookUI_OnRefreshBookList;

    }

    private void BookUI_OnRefreshBookList(object sender, EventArgs e) {
        RefreshBookList();
    }
}
