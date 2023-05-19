using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Color32 defaultAnswerColor = new Color32(32, 194, 245, 255);
    [SerializeField] Color32 correctAnswerColor = new Color32(255, 218, 0, 255);
    void Start()
    {
        DisplayQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        SetButtonState(false);
        Image buttonImage;
        correctAnswerIndex = question.GetCorrectAnswerIndex();
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = correctAnswerColor;
        }
        else
        {
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was:\n " + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = correctAnswerColor;
        }
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }

        SetButtonState(true);
    }

    void SetButtonState(bool interactable)
    {
        for (int i = 0; i < 4; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = interactable;
        }
    }
}
