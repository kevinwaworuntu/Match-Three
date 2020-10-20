using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Instance sebagai global access
    public static GameManager instance;
    int playerScore;
    public Text scoreText;

    public Text timerText, comboText;
    public GameObject restart;
    public float timer = 5f;
    bool isTimeUp = false;
    public bool isCombo = false;


    // singleton
    void Start()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
     
    }
    private void Update()
    {
        if (isTimeUp == false)
        {
            Timer();
            restart.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            timerText.text = "TIME'S UP";
            restart.SetActive(true);
            //GameObject.Find("Canvas").transform.Find("Restart").gameObject.SetActive(true);
            playerScore = 0;
        }
            
    }
    public void Timer()
    { 
        if(timer >= 1f && Time.deltaTime>=0f)
        {
            timer-=Time.deltaTime;
            timerText.text = ((int)timer).ToString();
            
        }
        else isTimeUp = true;
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restart.SetActive(false);
    }
    
  

    //Update score dan ui
    public void GetScore(int point)
    {
        if (isCombo == false)
        {
            playerScore += point;
            scoreText.text = playerScore.ToString();
            comboText.text = "Combo X1";
        }
        else
        {
            playerScore += (point * 2);
            scoreText.text = playerScore.ToString();
            comboText.text = "Combo X2";
        }
    }
}
