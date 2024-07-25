using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

    private List<CatGameSO> listCatGames;
    public event EventHandler OnInventoryRefresh;

    public Inventory() {
        listCatGames = new List<CatGameSO>(9);
        for (int itemCount = 0; itemCount < 9; itemCount++) {
            listCatGames.Add(null);
        }
    }

    public void AddCatGame(CatGameSO catGameSO) {

        int flag = 0;

        for (int counter = 0; counter < 8; counter++) {
            if (listCatGames[counter] == null && flag == 0) {
                CatGameSO cgi = catGameSO;
                listCatGames[counter] = cgi;
                flag = 1;
            }
        }

        OnInventoryRefresh.Invoke(listCatGames, EventArgs.Empty);

    }

    public List<CatGameSO> GetCatGames() {
    
        return listCatGames;
    
    }


}
