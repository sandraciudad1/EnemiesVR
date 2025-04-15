using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scoreScene_Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI firstScore;
    [SerializeField] TextMeshProUGUI secondScore;
    [SerializeField] TextMeshProUGUI thirdScore;

    void Start()
    {
        gameManager.gameManagerInstance.LoadProgress();
        updateRanking(gameManager.gameManagerInstance.points);
    }

    void updateRanking(int points)
    {
        int first = gameManager.gameManagerInstance.first;
        int second = gameManager.gameManagerInstance.second;
        int third = gameManager.gameManagerInstance.third;

        if (points > first)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.second;
            gameManager.gameManagerInstance.second = gameManager.gameManagerInstance.first;
            gameManager.gameManagerInstance.first = gameManager.gameManagerInstance.points;
        }
        else if (points > second)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.second;
            gameManager.gameManagerInstance.second = gameManager.gameManagerInstance.points;
        }
        else if (points > third)
        {
            gameManager.gameManagerInstance.third = gameManager.gameManagerInstance.points;
        }

        firstScore.text = gameManager.gameManagerInstance.first.ToString();
        secondScore.text = gameManager.gameManagerInstance.second.ToString();
        thirdScore.text = gameManager.gameManagerInstance.third.ToString();
        gameManager.gameManagerInstance.SaveProgress();
    }
}
