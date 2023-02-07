using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Health enemy;
    public Text scoreText;
    public int ScoreNum;
    public bool GetScore;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreNum.ToString();

        if(GetScore == true)
        {
            ScoreNum = ScoreNum + 5;
            GetScore = false;
        }
        
    }
}
