using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    bool onEndScreen = false;
    void Awake()
    {
        onEndScreen = false;
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
    }
    void Start()
    {
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if (quiz.isComplete && !onEndScreen)
        {

            endScreen.gameObject.SetActive(true);

            onEndScreen = true;
            endScreen.ShowFinalScore();

            quiz.gameObject.SetActive(false);
        }
    }

    public void OnPlayAgainPressed()
    {
        SceneManager.LoadScene(0);
    }
}
