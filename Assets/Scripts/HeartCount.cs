using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/CreatHeartCAsset")]
public class HeartCount : ScriptableObject
{
    public int stageNow = 1;
    public int allHeartNow = 0;
    public int heartThisStage = 0;
    public int heartNotThisStage;
    public int finishHeart = 29;
    public int finishHeartNow = 0;

}
