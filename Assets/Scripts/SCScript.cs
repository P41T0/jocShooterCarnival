using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text enemiesShooted;
    [SerializeField] private TMP_Text secondsRemainingText;
    [SerializeField] private TMP_Text bestScoreText;
    private int numEnemsHit;
    private float secondsRemaining;
    private int bestScore;

    void Start()
    {
        numEnemsHit = 0;
        enemiesShooted.text = numEnemsHit.ToString();
        secondsRemaining = 120.0f;
        secondsRemainingText.text = ConvertToMinutesAndSeconds(secondsRemaining);
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        else
        {
            bestScore = 0;
        }
        bestScoreText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        secondsRemaining -= Time.deltaTime;
        if (secondsRemaining > 0)
        {
            secondsRemainingText.text = ConvertToMinutesAndSeconds(secondsRemaining);
        }
        else
        {
            if (numEnemsHit > bestScore)
            {
                PlayerPrefs.SetInt("BestScore",numEnemsHit);
            }

            SceneManager.LoadScene(0);
        }

    }


    string ConvertToMinutesAndSeconds(float temps)
    {
        int minutes = Mathf.FloorToInt(temps / 60);
        int seconds = Mathf.FloorToInt(temps % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void IncreaseScore()
    {
        numEnemsHit++;
        enemiesShooted.text = numEnemsHit.ToString();
    }
}
