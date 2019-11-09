using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int hole1Score;
    public DetectionArea DetectionArea1;
    public int hole2Score;
    public DetectionArea DetectionArea2;
    public int hole3Score;
    public DetectionArea DetectionArea3;

    [Space]

    public int score;
    public TextMesh displayScoreText;

    [Space]
    public int gameDuration;
    private  float gameTimer;
    private float onTimerChanger;

    [Space]
    public GameObject player;
    public Button ReturnButton;
    public Button TryAgainButton;
    public Text timerText;

    static GameManager _instance;
    public static GameManager Instance {
        get { return _instance; }
    }

    private void OnValidate()
    {
        DetectionArea1.GetComponentInChildren<TextMesh>().text = hole1Score.ToString();
        DetectionArea2.GetComponentInChildren<TextMesh>().text = hole2Score.ToString();
        DetectionArea3.GetComponentInChildren<TextMesh>().text = hole3Score.ToString();
  
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!_instance)
        {
            _instance = this;
        }
        gameTimer = gameDuration +4;
        onTimerChanger = gameTimer;

    }

    private void Update()
    {
        displayScoreText.text = score.ToString();
        GameTiming();
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    private void GameTiming()
    {
        gameTimer -= Time.deltaTime;
        TimerTextEffect();
        if (OnTimerChanage() && gameTimer>=0)
        {
            if ((int)gameTimer == gameDuration+3)
            {
                player.SetActive(false);
            }
            if ((int)gameTimer == gameDuration)
            {
                player.SetActive(true);
            }
            if ((int)gameTimer > 0 && (int)gameTimer <= 3)
            {
                timerText.fontSize = 80;
                timerText.color = Color.red;
                timerText.text = ((int)gameTimer).ToString();
            }
            else if ((int)gameTimer <= gameDuration+3 && (int)gameTimer > gameDuration)
            {
                timerText.fontSize = 80;
                timerText.color = Color.black;
                timerText.text = ((int)gameTimer - gameDuration).ToString();
            }
            else {
                timerText.text = "";
            }
            if ((int)gameTimer == 0)
            {
                OnGameEnd();
            }
        }


    }
    private bool OnTimerChanage()
    {
       if((int)onTimerChanger != (int)gameTimer)
        {
            onTimerChanger = gameTimer;
            return true;
        }
 
        return false;
    }

    private void TimerTextEffect() {
        if ((int)gameTimer > 0)
        {
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, timerText.color.a - Time.deltaTime);
            timerText.fontSize--;
        }
    }
    private void OnGameEnd()
    {
        timerText.fontSize = 80;
        timerText.color = Color.grey;
        player.GetComponent<Player>().OnGameEnd();
        InsertRank(score);
        player.SetActive(false);

    }

    private void InsertRank(int newScore)
    {
        print(RankData.CheckRank(newScore));
        int rank = RankData.CheckRank(newScore);
        if (rank == 0)
        {
            timerText.fontSize = 40;
            timerText.text = "Amazing! You got the highest score!";
            RankData.SetNewRecord(newScore);
            SaveRankManager.Save();
            ReturnButton.gameObject.SetActive(true);
        }
        else if (rank > 0 && rank < 5)
        {
            timerText.text = "Try again";
            RankData.SetNewRecord(newScore);
            SaveRankManager.Save();
            TryAgainButton.gameObject.SetActive(true);
        }
        else 
        {
            timerText.fontSize = 40;
            timerText.text = "Your score is low. Try again";
            TryAgainButton.gameObject.SetActive(true);
        }
      
        
    }
}

