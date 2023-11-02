using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level2Finish : MonoBehaviour
{
    private bool levelCompleted = false;
    public int winHeart ;

    public GameObject _slide;
    public HeartCount myHeartCount;
    public int HeartNow = 0;
    public int finishHeart = 29;
    public GameObject heart;


    private void Start()
    {
        HeartNow = myHeartCount.finishHeartNow;
        _slide.GetComponent<Slider>().maxValue = finishHeart;
    }

    private void Update(){
        _slide.GetComponent<Slider>().value = myHeartCount.finishHeartNow;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted )
        {
            if(myHeartCount.finishHeartNow >= myHeartCount.finishHeart){
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }
        }
        
        if(collision.gameObject.CompareTag("Heart2")){
            Debug.Log("Get Heart!");
            Destroy(collision.gameObject);
            myHeartCount.finishHeartNow ++;  
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
