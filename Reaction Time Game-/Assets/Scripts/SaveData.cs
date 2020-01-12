using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SaveData
{
    public double highScoreE;
    public double highScoreM;
    public double highScoreH;


    public SaveData(ReactionGameScript game){
        highScoreE = game.highScoreE;
        highScoreM = game.highScoreM;
        highScoreH = game.highScoreH;
    }


}
