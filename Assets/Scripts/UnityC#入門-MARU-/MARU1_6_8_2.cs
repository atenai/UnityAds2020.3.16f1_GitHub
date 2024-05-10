using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_8_2 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int scoreA = 100;
        int scoreB = 150;
        int scoreC = 170;
        int ScoreD = 200;

        Debug.Log(SumScore(scoreA, scoreB));
        Debug.Log(SumScore(scoreA, scoreB, scoreC));
        Debug.Log(SumScore(scoreA, scoreB, scoreC, ScoreD));
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    //2つのスコアを足し合わせる関数
    int SumScore(int score1, int score2)
    {
        int totalScore;

        totalScore = score1 + score2;

        return totalScore;
    }

    //3つのスコアを足し合わせる関数
    int SumScore(int score1, int score2, int score3)
    {
        int totalScore;

        totalScore = score1 + score2 + score3;

        return totalScore;
    }

    //4つのスコアを足し合わせる関数
    int SumScore(int score1, int score2, int score3, int score4)
    {
        int totalScore;

        totalScore = score1 + score2 + score3 + score4;

        return totalScore;
    }
}
