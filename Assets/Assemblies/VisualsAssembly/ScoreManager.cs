using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Score Related
    public float Score;    
    public static float HighScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;

    private float _pointsPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _pointsPerSecond = UnityEngine.Random.Range(1f, 20f);

        if (!Player.PlayerDead)
        {
            if (Score > HighScore)
            {
                HighScore = Score;
            }
        }
    }

    void FixedUpdate()
    {
        //Score Related
        ScoreText.text = "Score: " + (int)Score;
        HighScoreText.text = "High Score: " + (int)HighScore;
        if (!Player.PlayerDead)
            Score += _pointsPerSecond * Time.deltaTime;
    }
}
