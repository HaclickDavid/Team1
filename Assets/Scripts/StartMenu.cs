using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public HeartCount myHeartCount;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        myHeartCount.stageNow = 1;
        myHeartCount.allHeartNow = 0;
        myHeartCount.heartThisStage = 0;
        myHeartCount.heartNotThisStage = 0;
    }
}
