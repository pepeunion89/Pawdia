using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New game item", menuName = "CatGameSO/Create")]
public class CatGameSO : ScriptableObject
{
    public int raceID;
    public string gameName;
    public Sprite gameSprite;
    public int gamePrice;
}
