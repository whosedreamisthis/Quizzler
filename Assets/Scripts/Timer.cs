using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool isAnsweringQuestion = true;
    public float fillFraction;
    public bool loadNextQuestion = false;
    float timerValue;
    [SerializeField] float timeToCompleteQuestion = 30;
    [SerializeField] float timeToShowCorrectAnswer = 10;

    void Start()
    {
        isAnsweringQuestion = true;
        timerValue = timeToCompleteQuestion;
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            fillFraction = timerValue / timeToCompleteQuestion;
            if (timerValue <= 0)
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            fillFraction = timerValue / timeToShowCorrectAnswer;
            //print("here 3");
            if (timerValue <= 0)
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
