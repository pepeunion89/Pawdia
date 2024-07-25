using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New cat item", menuName = "CatSO/Create")]
public class CatSO : ScriptableObject
{

    public int raceID;
    public string raceName;
    public Sprite raceSprite;
    public CatGameSO catGameSO;

}
