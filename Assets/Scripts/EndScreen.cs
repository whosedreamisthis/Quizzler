using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update
    [SerializeField] ScoreKeeper scoreKeeper;
    void Awake()
    {
        //scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "You scored " + scoreKeeper.CalculateScore() + "%";
    }


}
