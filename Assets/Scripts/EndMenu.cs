using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public HeartCount myHeartCount;
    public void Quit()
    {
        myHeartCount.stageNow = 0;
        myHeartCount.allHeartNow  = 0;
        myHeartCount.heartNotThisStage = 0;
        myHeartCount.heartThisStage = 0;
        Application.Quit();
    }
}
