using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Static Instance
    public static gameManager gameManagerInstance { get; private set; }

    //Static Variables
    public int points;
    public int first;
    public int second;
    public int third;

    private void Awake()
    {
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadProgress();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("first", first);
        PlayerPrefs.SetInt("second", second);
        PlayerPrefs.SetInt("third", third);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        points = PlayerPrefs.GetInt("points", 0);
        first = PlayerPrefs.GetInt("first", 0);
        second = PlayerPrefs.GetInt("second", 0);
        third = PlayerPrefs.GetInt("third", 0);
    }
}
