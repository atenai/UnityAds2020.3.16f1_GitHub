using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MARU1_6_8_1 : MonoBehaviour
{
    void Start()
    {
        //Debug.Log("Start");

        int scoreA = 100;
        int scoreB = 150;
        int scoreC = 170;
        int ScoreD = 200;

        Debug.Log(SumTwoScore(scoreA, scoreB));
        Debug.Log(SumThreeScore(scoreA, scoreB, scoreC));
        Debug.Log(SumFourScore(scoreA, scoreB, scoreC, ScoreD));
    }

    void Update()
    {
        //Debug.Log("Update");
    }

    //2つのスコアを足し合わせる関数
    int SumTwoScore(int score1, int score2)
    {
        int totalScore;

        totalScore = score1 + score2;

        return totalScore;
    }

    //3つのスコアを足し合わせる関数
    int SumThreeScore(int score1, int score2, int score3)
    {
        int totalScore;

        totalScore = score1 + score2 + score3;

        return totalScore;
    }

    //4つのスコアを足し合わせる関数
    int SumFourScore(int score1, int score2, int score3, int score4)
    {
        int totalScore;

        totalScore = score1 + score2 + score3 + score4;

        return totalScore;
    }
}
