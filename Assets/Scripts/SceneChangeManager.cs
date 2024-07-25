using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeManager : MonoBehaviour
{
    public static int startGameFlag = 0;
    public static int sceneFlag = 0;
    public static CatSO catSO;
    public static float[] playerPositionXY = new float[2];
    public static CatGameSO playerGameEquipped;
    public static List<CatSO> listBookCatSO = new List<CatSO>(8);

}
