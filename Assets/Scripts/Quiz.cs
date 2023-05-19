using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO[] questions;
    int currentQuestion;
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;


    int correctAnswerIndex;
    bool hasAnsweredEarly;
    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Color32 defaultAnswerColor = new Color32(32, 194, 245, 255);
    [SerializeField] Color32 correctAnswerColor = new Color32(255, 218, 0, 255);

    [Header("Timer")]
    Timer timer;
    [SerializeField] Image timerImage;
    void Start()
    {
        currentQuestion = -1;
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        SetButtonState(false);
        correctAnswerIndex = questions[currentQuestion].GetCorrectAnswerIndex();

        DisplayAnswer(index);

        timer.CancelTimer();
    }

    void GetNextQuestion()
    {
        currentQuestion++;
        if (currentQuestion >= questions.Length)
        {
            currentQuestion = 0;
        }
        Debug.Log("currentQuestion " + currentQuestion);
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = correctAnswerColor;
        }
        else
        {
            string correctAnswer = questions[currentQuestion].GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was:\n " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = correctAnswerColor;
        }
    }
    void DisplayQuestion()
    {
        questionText.text = questions[currentQuestion].GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].GetAnswer(i);
        }
    }

    void SetButtonState(bool interactable)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = interactable;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            buttonImage.color = defaultAnswerColor;
        }
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            timer.loadNextQuestion = false;
            GetNextQuestion();
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
}
