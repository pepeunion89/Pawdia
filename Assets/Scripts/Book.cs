using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book
{
    private List<CatSO> listCatSO;
    public event EventHandler RefreshBookList;

    public Book() {

        listCatSO = new List<CatSO>();

        for (int catSoCounter = 0; catSoCounter < 8; catSoCounter++) {
            listCatSO.Add(null);
        }

    }

    public void AddCatSOToBook(int idx, CatSO catSO = null) {

        listCatSO[idx] = catSO;

        RefreshBookList.Invoke(this, EventArgs.Empty);
    }

    public List<CatSO> GetCatSOList() {
        
        return listCatSO;
    
    }

}
