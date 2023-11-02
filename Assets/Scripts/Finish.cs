using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{
    private bool levelCompleted = false;
    public int winHeart ;

    public GameObject _slide;
    public HeartCount myHeartCount;

    private void Start()
    {
        _slide.GetComponent<Slider>().maxValue = winHeart;
    }

    private void Update(){
        _slide.GetComponent<Slider>().value = myHeartCount.heartThisStage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted && myHeartCount.heartThisStage >= winHeart)
        {
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        myHeartCount.heartThisStage = 0;
        myHeartCount.heartNotThisStage = myHeartCount.heartNotThisStage + winHeart;
        myHeartCount.stageNow ++;
    }
}
